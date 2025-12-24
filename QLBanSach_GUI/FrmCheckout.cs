using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLBanSach_BLL;
using QLBanSach_DAL;
using QLBanSach_DTO; // <-- add this
using QRCoder;

namespace QLBanSach_GUI
{
    public partial class FrmCheckout : Form
    {
        private readonly BanHangBLL banHang = new BanHangBLL();
        private readonly KhuyenMaiBLL khuyenMai = new KhuyenMaiBLL();

        private readonly NhanVienDTO _currentNv; // now resolves to QLBanSach_DTO.NhanVienDTO
        private int? _selectedCustomerId;

        private DataTable dtBooks;
        private DataTable dtCart;

        // New ctor that gets current employee
        public FrmCheckout(NhanVienDTO currentNv)
        {
            _currentNv = currentNv ?? throw new ArgumentNullException(nameof(currentNv));
            InitializeComponent();
            InitDataTables();
            WireUpEvents();
            LoadBooks();
            ApplyContext();
            UpdateTotalLabel();
        }

        // Keep parameterless constructor only if designer requires; avoid using it at runtime
        public FrmCheckout() { InitializeComponent(); }

        private void ApplyContext()
        {
            // hide manual entry; show context text
            txtMaNV.Visible = false;
            txtMaKH.Visible = false;

            // show employee info
            lblMaNV.Text = _currentNv != null
                ? $"Nhân viên: {_currentNv.HoTen} ({_currentNv.MaNV})"
                : "Nhân viên: (chưa xác định)";

            // show customer info (after SetSelectedCustomer is called)
            lblMaKH.Text = _selectedCustomerId.HasValue
                ? $"Khách hàng: #{_selectedCustomerId.Value}"
                : "Khách hàng: (chưa chọn)";
        }

        private void WireUpEvents()
        {
            btnAddToCart.Click += btnAddToCart_Click;
            btnRemoveFromCart.Click += btnRemoveFromCart_Click;
            btnCheckout.Click += btnCheckout_Click;

            dgvCart.CellEndEdit += (s, e) => RecalculateCartRow(e.RowIndex);
            dgvCart.UserDeletedRow += (s, e) => UpdateTotalLabel();
        }

        // keep this method for FrmMain to call
        public void SetSelectedCustomer(int maKh)
        {
            _selectedCustomerId = maKh; 
            lblMaKH.Text = $"Khách hàng: #{maKh}";
        }

        private void InitDataTables()
        {
            dtBooks = new DataTable();
            dgvBooks.ReadOnly = true;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.DataSource = dtBooks;

            dtCart = new DataTable();
            dtCart.Columns.Add("MaSach", typeof(int));
            dtCart.Columns.Add("TenSach", typeof(string));
            dtCart.Columns.Add("SoLuong", typeof(int));
            dtCart.Columns.Add("DonGia", typeof(decimal));
            dtCart.Columns.Add("ThanhTien", typeof(decimal));
            dgvCart.DataSource = dtCart;

            dgvCart.AllowUserToAddRows = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.MultiSelect = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCart.Columns["MaSach"] != null) dgvCart.Columns["MaSach"].ReadOnly = true;
            if (dgvCart.Columns["TenSach"] != null) dgvCart.Columns["TenSach"].ReadOnly = true;
            if (dgvCart.Columns["DonGia"] != null) dgvCart.Columns["DonGia"].ReadOnly = true;
            if (dgvCart.Columns["ThanhTien"] != null) dgvCart.Columns["ThanhTien"].ReadOnly = true;
        }

        private void LoadBooks()
        {
            var sql = "SELECT MaSach, TenSach, DonGia, SoLuong AS SoLuongTon FROM Sach";
            dtBooks = DatabaseHelper.GetData(sql);
            dgvBooks.DataSource = dtBooks;

            if (dgvBooks.Columns["MaSach"] != null) dgvBooks.Columns["MaSach"].HeaderText = "Mã sách";
            if (dgvBooks.Columns["TenSach"] != null) dgvBooks.Columns["TenSach"].HeaderText = "Tên sách";
            if (dgvBooks.Columns["DonGia"] != null) dgvBooks.Columns["DonGia"].HeaderText = "Đơn giá";
            if (dgvBooks.Columns["SoLuongTon"] != null) dgvBooks.Columns["SoLuongTon"].HeaderText = "Tồn";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null) return;
            var row = (dgvBooks.CurrentRow.DataBoundItem as DataRowView)?.Row;
            if (row == null) return;

            int maSach = Convert.ToInt32(row["MaSach"]);
            string tenSach = row["TenSach"].ToString();
            decimal donGia = Convert.ToDecimal(row["DonGia"]);
            int ton = row.Table.Columns.Contains("SoLuongTon") ? Convert.ToInt32(row["SoLuongTon"]) : 999999;

            var existing = dtCart.AsEnumerable().FirstOrDefault(r => r.Field<int>("MaSach") == maSach);
            if (existing != null)
            {
                int soLuong = existing.Field<int>("SoLuong") + 1;
                if (soLuong > ton)
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho.");
                    return;
                }
                existing["SoLuong"] = soLuong;
                existing["ThanhTien"] = donGia * soLuong;
            }
            else
            {
                var newRow = dtCart.NewRow();
                newRow["MaSach"] = maSach;
                newRow["TenSach"] = tenSach;
                newRow["SoLuong"] = 1;
                newRow["DonGia"] = donGia;
                newRow["ThanhTien"] = donGia * 1;
                dtCart.Rows.Add(newRow);
            }
            UpdateTotalLabel();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            var drv = dgvCart.CurrentRow.DataBoundItem as DataRowView;
            drv?.Row.Delete();
            UpdateTotalLabel();
        }

        private void RecalculateCartRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dtCart.Rows.Count) return;
            var r = dtCart.Rows[rowIndex];

            int soLuong;
            if (!int.TryParse(Convert.ToString(r["SoLuong"]), out soLuong) || soLuong <= 0)
            {
                soLuong = 1;
                r["SoLuong"] = 1;
            }

            decimal donGia = Convert.ToDecimal(r["DonGia"]);
            r["ThanhTien"] = donGia * soLuong;
            UpdateTotalLabel();
        }

        private decimal GetCartTotal()
        {
            return dtCart.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
        }

        private void UpdateTotalLabel()
        {
            lblTotal.Text = $"Tổng: {GetCartTotal():#,##0}";
        }

        private DataTable BuildChiTietForCheckout()
        {
            var chiTiet = new DataTable();
            chiTiet.Columns.Add("MaSach", typeof(int));
            chiTiet.Columns.Add("SoLuong", typeof(int));
            chiTiet.Columns.Add("DonGia", typeof(decimal));

            foreach (DataRow r in dtCart.Rows)
            {
                chiTiet.Rows.Add(
                    r.Field<int>("MaSach"),
                    r.Field<int>("SoLuong"),
                    r.Field<decimal>("DonGia")
                );
            }
            return chiTiet;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Employee from login
            string maNV = _currentNv?.MaNV;
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Không xác định được nhân viên đăng nhập.");
                return;
            }

            // Customer from selection
            if (!_selectedCustomerId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi thanh toán.");
                return;
            }
            int maKH = _selectedCustomerId.Value;

            if (dtCart.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống.");
                return;
            }

            var chiTiet = BuildChiTietForCheckout();

            DataRow promo = null;
            var coupon = txtCoupon.Text.Trim();
            if (!string.IsNullOrEmpty(coupon) && khuyenMai.ValidateCoupon(coupon))
            {
                promo = khuyenMai.GetPromotionByCoupon(coupon);
            }

            try
            {
                int maHD = banHang.Checkout(maNV, maKH, chiTiet, promo);

                decimal totalPayable = 0m;
                var dt = DatabaseHelper.ExecuteQuery("SELECT TongTien FROM HoaDon WHERE MaHD=@MaHD",
                    new SqlParameter[] { new SqlParameter("@MaHD", maHD) });
                if (dt.Rows.Count > 0) decimal.TryParse(dt.Rows[0][0].ToString(), out totalPayable);

                GeneratePaymentQr(maHD, totalPayable);

                MessageBox.Show($"Tạo hoá đơn thành công. Mã HD: {maHD}\nQuét QR để thanh toán: {totalPayable:#,##0}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
            }
        }

        private void GeneratePaymentQr(int maHD, decimal amount)
        {
            string payload = $"PAY|HD:{maHD}|AMT:{amount:0.00}|CUR:VND";

            using (var generator = new QRCodeGenerator())
            {
                QRCodeData data = generator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
                using (var qrCode = new QRCode(data))
                {
                    Bitmap qrImage = qrCode.GetGraphic(10);
                    picQr.Image = qrImage;
                }
            }
        }

        private void splitMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
