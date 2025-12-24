using QLBanSach_BLL;
using QLBanSach_DAL;
using QLBanSach_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_POS : UserControl
    {
        // Instantiate lazily to avoid design-time exceptions
        private SachDAL sachDAL;
        private KhuyenMaiDAL kmDAL;

        private HoaDonBLL hoaDonBLL;
        private NhanVienDAL nhanVienDAL;

        // Design-mode helper
        private bool IsDesignMode =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
            (Site?.DesignMode ?? false);

        public UC_POS()
        {
            InitializeComponent();
        }

        private void UC_POS_Load(object sender, EventArgs e)
        {
            // Always safe to setup columns
            SetupListView();

            // Skip any DB / service calls when in designer
            if (IsDesignMode) return;

            // Lazy init services
            sachDAL = sachDAL ?? new SachDAL();
            kmDAL = kmDAL ?? new KhuyenMaiDAL();
            hoaDonBLL = hoaDonBLL ?? new HoaDonBLL();
            nhanVienDAL = nhanVienDAL ?? new NhanVienDAL();

            LoadBooks();
            LoadKhuyenMai();
            TinhGiamGia();
        }

        private void LoadKhuyenMai()
        {
            DataTable dt = kmDAL.GetAllKhuyenMai();
            cbKhuyenMai.DataSource = dt;
            cbKhuyenMai.DisplayMember = "TenKM";
            cbKhuyenMai.ValueMember = "MaKM";
        }

        private void SetupListView()
        {
            lvCart.View = View.Details;
            lvCart.FullRowSelect = true;
            lvCart.GridLines = true;

            lvCart.Columns.Clear();
            lvCart.Columns.Add("Tên sách", 200);
            lvCart.Columns.Add("SL", 60);
            lvCart.Columns.Add("Đơn giá", 100);
            lvCart.Columns.Add("Thành tiền", 120);
        }

        private void LoadBooks()
        {
            flpBooks.Controls.Clear();
            List<SachDTO> list = sachDAL.GetAllSach();

            foreach (var s in list)
            {
                Panel p = new Panel { Size = new Size(160, 220), BorderStyle = BorderStyle.FixedSingle, Tag = s }; // giữ DTO trong Tag

                PictureBox pic = new PictureBox { Size = new Size(150, 150), SizeMode = PictureBoxSizeMode.Zoom };
                if (!string.IsNullOrEmpty(s.AnhBia) && System.IO.File.Exists(s.AnhBia))
                    pic.Image = Image.FromFile(s.AnhBia);

                Label lbl = new Label { Text = s.TenSach, AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Bottom, Height = 30 };

                p.Controls.Add(pic);
                p.Controls.Add(lbl);

                p.Click += (sender, e) =>
                {
                    var dto = (sender as Panel)?.Tag as SachDTO;
                    if (dto == null) return;
                    AddToCart(dto.MaSach, dto.TenSach, 1, dto.DonGia);
                };

                flpBooks.Controls.Add(p);
            }
        }

        // ✅ FIXED: Complete checkout implementation
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lvCart.Items.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }
            var r = MessageBox.Show("Xác nhận thanh toán?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;

            try
            {
                var chiTiet = ConvertCartToDataTable();

                // Kiểm tra có MaSach hợp lệ
                if (chiTiet.AsEnumerable().Any(row => Convert.ToInt32(row["MaSach"]) <= 0))
                {
                    MessageBox.Show("Thiếu mã sách trong giỏ. Vui lòng thêm lại từ danh sách sách.", "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maNV = "NV01"; // TODO: thay bằng NV đăng nhập
                int maKH = 1;         // TODO: thay bằng khách được chọn

                int maHD = hoaDonBLL.LuuHoaDon(maNV, maKH, chiTiet);

                // Build promotion info for invoice header
                string kmInfo = "-";
                var drv = cbKhuyenMai.SelectedItem as DataRowView;
                if (drv != null)
                {
                    var tenKm = Convert.ToString(drv.Row["TenKM"]);
                    var hinhThuc = Convert.ToString(drv.Row["HinhThuc"]);
                    var giaTriStr = Convert.ToString(drv.Row["GiaTri"]);
                    var maCoupon = drv.Row.Table.Columns.Contains("MaCoupon") ? Convert.ToString(drv.Row["MaCoupon"]) : null;
                    long giamGia = SafeLong(txtGiamGia.Text);
                    if (!string.IsNullOrEmpty(tenKm))
                    {
                        if (string.Equals(hinhThuc, "COUPON", StringComparison.OrdinalIgnoreCase))
                            kmInfo = $"{tenKm} (COUPON: {maCoupon}) - Giảm {giamGia:N0}";
                        else if (string.Equals(hinhThuc, "%", StringComparison.OrdinalIgnoreCase))
                            kmInfo = $"{tenKm} ({giaTriStr}%) - Giảm {giamGia:N0}";
                        else if (string.Equals(hinhThuc, "TANG1", StringComparison.OrdinalIgnoreCase))
                            kmInfo = $"{tenKm} (TẶNG 1) - Giảm {giamGia:N0}";
                    }
                }

                // Show invoice details form
                var tongThanhToan = txtThanhToan.Text; // formatted string
                var frm = new FrmChiTietHoaDon(chiTiet, maHD, tongThanhToan, DateTime.Now, kmInfo);
                frm.Show();

                MessageBox.Show($"Thanh toán thành công! Mã hóa đơn: {maHD}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset UI
                lvCart.Items.Clear();
                txtGiamGia.Text = "0";
                txtVAT.Text = "0";
                txtTongTien.Text = "0";
                txtThanhToan.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ NEW: Convert ListView cart to DataTable for saving
        private DataTable ConvertCartToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSach", typeof(int));
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGia", typeof(decimal));
            dt.Columns.Add("ThanhTien", typeof(decimal));

            foreach (ListViewItem item in lvCart.Items)
            {
                int maSach = SafeInt(item.Tag?.ToString());
                string tenSach = item.SubItems[0].Text;
                int soLuong = SafeInt(item.SubItems[1].Text);

                decimal donGia = SafeDecimal(item.SubItems[2].Text);
                decimal thanhTien = SafeDecimal(item.SubItems[3].Text);

                dt.Rows.Add(maSach, tenSach, soLuong, donGia, thanhTien);
            }
            return dt;
        }

        private static int SafeInt(string s)
        {
            int v;
            return int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out v) ? v : 0;
        }

        private static decimal SafeDecimal(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0m;
            // chấp nhận "10,000", "10.000", "10000"
            var cleaned = s.Replace(",", "").Replace(".", "");
            decimal v;
            return decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, out v) ? v : 0m;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lazy init DAL if needed (avoid design-time nulls)
                if (sachDAL == null) sachDAL = new SachDAL();

                var books = sachDAL.GetAllSach();
                if (books == null || books.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu sách để thêm.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (Form pick = new Form()
                {
                    Text = "Thêm sách vào giỏ",
                    Width = 420,
                    Height = 220,
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                })
                {
                    var lblSach = new Label { Left = 12, Top = 16, Width = 380, Text = "Chọn sách:" };
                    var cbSach = new ComboBox
                    {
                        Left = 12, Top = 40, Width = 380,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    // Bind list of books
                    cbSach.DataSource = books.Select(b => new
                    {
                        MaSach = b.MaSach,
                        TenSach = b.TenSach,
                        DonGia = b.DonGia
                    }).ToList();
                    cbSach.DisplayMember = "TenSach";
                    cbSach.ValueMember = "MaSach";

                    var lblSL = new Label { Left = 12, Top = 78, Width = 120, Text = "Số lượng:" };
                    var nudSL = new NumericUpDown
                    {
                        Left = 132, Top = 74, Width = 80,
                        Minimum = 1, Maximum = 100, Value = 1
                    };

                    var btnOK = new Button { Text = "Thêm", Left = 236, Width = 75, Top = 120, DialogResult = DialogResult.OK };
                    var btnCancel = new Button { Text = "Hủy", Left = 317, Width = 75, Top = 120, DialogResult = DialogResult.Cancel };

                    pick.Controls.Add(lblSach);
                    pick.Controls.Add(cbSach);
                    pick.Controls.Add(lblSL);
                    pick.Controls.Add(nudSL);
                    pick.Controls.Add(btnOK);
                    pick.Controls.Add(btnCancel);
                    pick.AcceptButton = btnOK;
                    pick.CancelButton = btnCancel;

                    if (pick.ShowDialog(this.FindForm()) != DialogResult.OK)
                        return;

                    // Extract selection
                    var selected = cbSach.SelectedItem;
                    if (selected == null)
                    {
                        MessageBox.Show("Chưa chọn sách.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Use reflection-safe dynamic access
                    int maSach = (int)selected.GetType().GetProperty("MaSach").GetValue(selected, null);
                    string tenSach = (string)selected.GetType().GetProperty("TenSach").GetValue(selected, null);
                    decimal donGia = (decimal)selected.GetType().GetProperty("DonGia").GetValue(selected, null);
                    int soLuong = (int)nudSL.Value;

                    AddToCart(maSach, tenSach, soLuong, donGia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào giỏ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateThanhToan()
        {
            long tongTien = 0;
            foreach (ListViewItem item in lvCart.Items)
                tongTien += SafeLong(item.SubItems[3].Text);

            txtTongTien.Text = tongTien.ToString("N0");

            long giamGia = SafeLong(txtGiamGia.Text);
            if (giamGia > tongTien) giamGia = tongTien; // clamp discount to subtotal

            long vat = (long)Math.Round(tongTien * 0.1, MidpointRounding.AwayFromZero);
            txtVAT.Text = vat.ToString("N0");

            long thanhToan = tongTien - giamGia + vat;
            if (thanhToan < 0) thanhToan = 0;
            txtThanhToan.Text = thanhToan.ToString("N0");
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
        }

        private void AddToCart(string tenSach, int soLuong, decimal donGia)
        {
            // Kiểm tra nếu đã có trong giỏ
            foreach (ListViewItem item in lvCart.Items)
            {
                if (item.SubItems[0].Text == tenSach)
                {
                    int sl = int.Parse(item.SubItems[1].Text) + soLuong;
                    item.SubItems[1].Text = sl.ToString();

                    decimal thanhTien = sl * donGia;
                    item.SubItems[3].Text = thanhTien.ToString("N0");

                    TinhGiamGia();
                    return;
                }
            }

            // Nếu chưa có → thêm mới
            decimal thanhTienNew = soLuong * donGia;

            ListViewItem lvi = new ListViewItem(tenSach);
            lvi.SubItems.Add(soLuong.ToString());
            lvi.SubItems.Add(donGia.ToString("N0"));
            lvi.SubItems.Add(thanhTienNew.ToString("N0"));

            lvCart.Items.Add(lvi);
            TinhGiamGia();
        }

        private void cbKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhGiamGia();
        }

        private void TinhGiamGia()
        {
            if (lvCart.Items.Count == 0)
            {
                txtGiamGia.Text = "0";
                UpdateThanhToan();
                return;
            }

            // Tự tính tổng giỏ hiện tại (không phụ thuộc txtTongTien để tránh stale)
            long tongTien = 0;
            foreach (ListViewItem item in lvCart.Items)
                tongTien += SafeLong(item.SubItems[3].Text);

            var drv = cbKhuyenMai.SelectedItem as DataRowView;
            if (drv == null)
            {
                txtGiamGia.Text = "0";
                UpdateThanhToan();
                return;
            }

            string hinhThuc = Convert.ToString(drv.Row["HinhThuc"]) ?? string.Empty;
            decimal giaTri = 0m;
            decimal.TryParse(Convert.ToString(drv.Row["GiaTri"]), NumberStyles.Number, CultureInfo.InvariantCulture, out giaTri);

            long giam = 0;
            switch (hinhThuc.Trim().ToUpperInvariant())
            {
                case "%":
                    giam = (long)Math.Round(tongTien * (double)(giaTri / 100m), MidpointRounding.AwayFromZero);
                    break;

                case "TANG1":
                    giam = (TongSoLuong() >= 2) ? GiaSachReNhat() : 0;
                    break;

                case "COUPON":
                    // Chỉ áp dụng khi mã nhập trùng với mã coupon của KM
                    string requiredCode = string.Empty;
                    if (drv.Row.Table.Columns.Contains("MaCoupon"))
                        requiredCode = Convert.ToString(drv.Row["MaCoupon"]);

                    var input = txtCoupon.Text?.Trim();
                    if (!string.IsNullOrEmpty(requiredCode) &&
                        string.Equals(requiredCode, input, StringComparison.OrdinalIgnoreCase))
                    {
                        giam = (long)Math.Round(giaTri, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        giam = 0; // không cho áp dụng nếu chưa nhập đúng mã
                    }
                    break;

                default:
                    giam = 0;
                    break;
            }

            if (giam < 0) giam = 0;
            if (giam > tongTien) giam = tongTien;

            txtGiamGia.Text = giam.ToString("N0");
            UpdateThanhToan();
        }

        private static long SafeLong(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            var cleaned = s.Replace(",", "").Replace(".", "");
            long v;
            return long.TryParse(cleaned, NumberStyles.Integer, CultureInfo.InvariantCulture, out v) ? v : 0;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            var dt = kmDAL.GetKhuyenMaiByCoupon(txtCoupon.Text?.Trim());
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Mã coupon không hợp lệ!");
                return;
            }

            var km = dt.Rows[0];
            // Chọn đúng chương trình KM và để TinhGiamGia() tính, có kiểm tra trùng mã
            cbKhuyenMai.SelectedValue = km["MaKM"];
            TinhGiamGia();
        }

        private int TongSoLuong()
        {
            int sl = 0;
            foreach (ListViewItem item in lvCart.Items)
                sl += int.Parse(item.SubItems[1].Text);
            return sl;
        }

        private long GiaSachReNhat()
        {
            long min = long.MaxValue;

            foreach (ListViewItem item in lvCart.Items)
            {
                // Đơn giá ở cột 2 (format "N0"): dùng SafeLong để xử lý cả "," và ".":
                long gia = SafeLong(item.SubItems[2].Text);
                if (gia <= 0) continue;
                if (gia < min) min = gia;
            }

            return (min == long.MaxValue) ? 0 : min;
        }

        // Overload có MaSach
        private void AddToCart(int maSach, string tenSach, int soLuong, decimal donGia)
        {
            foreach (ListViewItem item in lvCart.Items)
            {
                if (item.SubItems[0].Text == tenSach)
                {
                    int sl = SafeInt(item.SubItems[1].Text) + soLuong;
                    item.SubItems[1].Text = sl.ToString();
                    decimal thanhTien = sl * donGia;
                    item.SubItems[3].Text = thanhTien.ToString("N0");
                    TinhGiamGia();
                    return;
                }
            }

            decimal thanhTienNew = soLuong * donGia;
            ListViewItem lvi = new ListViewItem(tenSach);
            lvi.SubItems.Add(soLuong.ToString());
            lvi.SubItems.Add(donGia.ToString("N0"));
            lvi.SubItems.Add(thanhTienNew.ToString("N0"));
            lvi.Tag = maSach; // quan trọng: lưu MaSach
            lvCart.Items.Add(lvi);
            TinhGiamGia();
        }

        private void flpBooks_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
