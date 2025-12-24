using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using QLBanSach_BLL;
using QLBanSach_DTO;
using QLBanSach_DAL; // thêm DAL vì có DatabaseHelper

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_HoaDon : UserControl
    {
        private readonly SachBLL sachBLL = new SachBLL();
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();

        private readonly KhuyenMaiBLL khuyenMaiBLL = new KhuyenMaiBLL(); // thêm
        private decimal currentDiscount = 0m;       // số tiền giảm hiện tại
        private decimal currentVatPercent = 0m;     // % VAT hiện tại (ví dụ 10)
        
        DataTable dtGioHang = new DataTable();


        // A) Properties để parent form/ caller thiết lập
        public NhanVienDTO CurrentUser { get; set; }          // thông tin nhân viên đang đăng nhập
        public int CurrentCustomerId { get; set; } = 0;      // MaKH được chọn (0 = chưa chọn)


        private void UC_HoaDon_Load(object sender, EventArgs e)
        {

        }



        public UC_HoaDon()
        {
            InitializeComponent();
            InitGioHang();
            LoadSach(); // keep only ONE place to bind
        }

        // ---------- LOAD SÁCH ----------
        void LoadSach()
        {
            // Pick ONE source. Prefer BLL for business consistency.
            cboSach.DataSource = sachBLL.LayDanhSachSach();
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
        }


        // ---------- KHỞI TẠO GIỎ HÀNG ----------
        void InitGioHang()
        {
            dtGioHang.Columns.Add("MaSach", typeof(int));
            dtGioHang.Columns.Add("TenSach", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));   // changed to decimal
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal)); // changed to decimal
            dgvChiTiet.DataSource = dtGioHang;
        }

        // ---------- KHI CHỌN SÁCH ----------
        private void cboSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (cboSach.SelectedValue != null)
            if (cboSach.SelectedValue != null && cboSach.SelectedValue is int)
            {
                int maSach = Convert.ToInt32(cboSach.SelectedValue);
                var sach = sachBLL.LaySachTheoMa(maSach);
                if (sach != null)
                    txtDonGia.Text = sach.DonGia.ToString();
            }
        }

        //private void cboSach_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    if (cboSach.SelectedValue == null)
        //        return;

        //    // Lấy mã sách từ ValueMember
        //    int maSach = (int)cboSach.SelectedValue;

        //    // Lấy sách theo mã
        //    var sach = sachBLL.LaySachTheoMa(maSach);

        //    // Hiện đơn giá
        //    if (sach != null)
        //        txtDonGia.Text = sach.DonGia.ToString();
        //}

        // ---------- NÚT THÊM ----------
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (cboSach.SelectedValue == null) return;

            int ma = Convert.ToInt32(cboSach.SelectedValue);
            string ten = cboSach.Text;
            int sl = (int)numSoLuong.Value;

            decimal gia;
            if (!decimal.TryParse(txtDonGia.Text, out gia)) gia = 0m;

            decimal thanhTien = sl * gia;

            dtGioHang.Rows.Add(ma, ten, sl, gia, thanhTien);
            TinhTongTien();
        }

        // ---------- TÍNH TỔNG HIỂN THỊ (sau giảm + VAT)
        void TinhTongTien()
        {
            decimal tong = 0m;
            foreach (DataRow row in dtGioHang.Rows)
            {
                if (row["ThanhTien"] != DBNull.Value)
                    tong += Convert.ToDecimal(row["ThanhTien"]);
            }

            // áp dụng giảm giá
            decimal afterDiscount = tong - currentDiscount;
            if (afterDiscount < 0) afterDiscount = 0;

            // áp dụng VAT nếu có (%)
            decimal vatAmount = 0m;
            if (currentVatPercent > 0)
                vatAmount = Math.Round(afterDiscount * (currentVatPercent / 100m), 0);

            decimal payable = afterDiscount + vatAmount;

            lblTongTien.Text = $"Tổng tiền: {payable:N0} VNĐ";
        }

        // ---------- THANH TOÁN ----------
        //private void btnThanhToan_Click(object sender, EventArgs e)
        //{
        //    if (dtGioHang.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Chưa có sản phẩm nào!");
        //        return;
        //    }

        //    hoaDonBLL.LuuHoaDon(1, 1, dtGioHang); // giả định NV01 & KH01
        //    MessageBox.Show("Thanh toán thành công!");
        //    dtGioHang.Rows.Clear();
        //    TinhTongTien();
        //}

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            //if (dtGioHang.Rows.Count == 0)
            //{
            //    MessageBox.Show("Chưa có sản phẩm nào!");
            //    return;
            //}

            //// Giả định NV01, KH01
            //string maHD = HoaDonBLL.LuuHoaDon(1, 1, dtGioHang);

            //MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //// 👉 Mở form chi tiết hóa đơn
            //string tongTien = lblTongTien.Text;
            //FrmChiTietHoaDon frm = new FrmChiTietHoaDon(dtGioHang.Copy(), maHD, tongTien);
            //frm.ShowDialog();

            //// Reset giỏ hàng
            //dtGioHang.Rows.Clear();
            //TinhTongTien();
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra đã có user và khách hàng
            if (CurrentUser == null)
            {
                MessageBox.Show("Chưa đăng nhập. Vui lòng đăng nhập để thanh toán.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentCustomerId <= 0)
            {
                MessageBox.Show("Chưa chọn khách hàng. Vui lòng chọn khách hàng trước khi thanh toán.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // 1. Lưu hóa đơn & lấy mã hóa đơn mới

            try
            {
                string maNV = CurrentUser.MaNV; // lấy từ property do parent set
                int maKH = CurrentCustomerId;   // lấy từ property do parent set


                int maHD = hoaDonBLL.LuuHoaDon(maNV, maKH, dtGioHang, currentDiscount, currentVatPercent);

            // 2. Tổng tiền hiện tại (text trên giao diện)
            string tongTien = lblTongTien.Text;

            // 3. Copy giỏ hàng để gửi sang form chi tiết
            DataTable dtCopy = dtGioHang.Copy();

            // 4. Mở form chi tiết hóa đơn
            FrmChiTietHoaDon frm = new FrmChiTietHoaDon(dtCopy, maHD, tongTien, DateTime.Now);
            frm.ShowDialog();

            // 5. Reset giỏ hàng
            dtGioHang.Rows.Clear();
            currentDiscount = 0m;
            // currentVatPercent = 0m; // nếu muốn reset luôn
            TinhTongTien();

                MessageBox.Show("Thanh toán thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            try
            {
                // nhập mã coupon nhanh (có thể thay bằng form riêng)
                string coupon = PromptForCoupon();
                if (string.IsNullOrWhiteSpace(coupon))
                    return;

                // kiểm tra hợp lệ
                if (!khuyenMaiBLL.ValidateCoupon(coupon))
                {
                    MessageBox.Show("Coupon không hợp lệ hoặc hết hạn.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var kmRow = khuyenMaiBLL.GetPromotionByCoupon(coupon);
                if (kmRow == null)
                {
                    MessageBox.Show("Không tìm thấy khuyến mãi.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // tổng trước giảm
                decimal rawTotal = 0m;
                foreach (DataRow row in dtGioHang.Rows)
                {
                    if (row["ThanhTien"] != DBNull.Value)
                        rawTotal += Convert.ToDecimal(row["ThanhTien"]);
                }

                // tính số tiền giảm
                currentDiscount = khuyenMaiBLL.CalculateDiscount(kmRow, rawTotal);
                if (currentDiscount < 0) currentDiscount = 0;

                // nếu muốn set % VAT mặc định (ví dụ 10%), bạn có thể:
                // currentVatPercent = 10m; // hoặc lấy từ cấu hình hệ thống

                // cập nhật tổng hiển thị
                TinhTongTien();

                MessageBox.Show($"Áp dụng khuyến mãi thành công!\nGiảm: {currentDiscount:N0} VNĐ",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khuyến mãi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForCoupon()
        {
            using (Form prompt = new Form()
            {
                Text = "Nhập mã Coupon",
                Width = 320,
                Height = 140,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                var label = new Label() { Left = 12, Top = 12, Width = 280, Text = "Mã khuyến mãi (coupon):" };
                var txt = new TextBox() { Left = 12, Top = 36, Width = 280 };
                var ok = new Button() { Text = "OK", Left = 132, Width = 75, Top = 70, DialogResult = DialogResult.OK };
                var cancel = new Button() { Text = "Hủy", Left = 217, Width = 75, Top = 70, DialogResult = DialogResult.Cancel };
                prompt.Controls.Add(label);
                prompt.Controls.Add(txt);
                prompt.Controls.Add(ok);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = ok;
                prompt.CancelButton = cancel;

                return prompt.ShowDialog() == DialogResult.OK ? txt.Text : null;
            }
        }

        // Public API: cập nhật hiển thị khách đã chọn từ FrmMain (tránh truy cập control private trực tiếp)
        public void SetSelectedCustomerDisplay(string text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action)(() => SetSelectedCustomerDisplay(text)));
                return;
            }

            var ctrl = this.lblCustomerInfo; // đã là Guna2HtmlLabel
            if (ctrl != null) ctrl.Text = text;
        }

        // Thêm phương thức này để set khách và cập nhật UI một lần
        public void SetSelectedCustomer(int customerId, string customerDisplay)
        {
            CurrentCustomerId = customerId;

            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action)(() => lblCustomerInfo.Text = string.IsNullOrWhiteSpace(customerDisplay)
                    ? "Khách: Chưa chọn"
                    : $"Khách: {customerDisplay}"));
            }
            else
            {
                lblCustomerInfo.Text = string.IsNullOrWhiteSpace(customerDisplay)
                    ? "Khách: Chưa chọn"
                    : $"Khách: {customerDisplay}";
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGioHang.Rows.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng đang trống, không có gì để in.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Output path
                string invoicesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Invoices");
                Directory.CreateDirectory(invoicesDir);
                string fileName = $"HoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string fullPath = Path.Combine(invoicesDir, fileName);

                // Create PDF
                using (PdfDocument document = new PdfDocument())
                {
                    document.Info.Title = "Hóa đơn bán sách";
                    PdfPage page = document.AddPage();
                    page.Size = PdfSharp.PageSize.A4;
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Fonts and brushes
                    XFont titleFont = new XFont("Segoe UI", 16, XFontStyle.Bold);
                    XFont boldFont = new XFont("Segoe UI", 11, XFontStyle.Bold);
                    XFont normalFont = new XFont("Segoe UI", 11, XFontStyle.Regular);
                    XBrush black = XBrushes.Black;
                    XPen gridPen = new XPen(XColors.LightGray, 0.6);

                    double margin = 36; // ~0.5 inch
                    double y = margin;

                    // Header
                    gfx.DrawString("Hóa đơn bán sách", titleFont, black, new XRect(0, y, page.Width, 24), XStringFormats.TopCenter);
                    y += 34;

                    gfx.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", normalFont, black, margin, y);
                    y += 18;

                    if (CurrentUser != null)
                    {
                        gfx.DrawString($"Nhân viên: {CurrentUser.HoTen} (Mã: {CurrentUser.MaNV})", normalFont, black, margin, y);
                        y += 18;
                    }

                    gfx.DrawString(lblCustomerInfo.Text ?? "Khách: Chưa chọn", normalFont, black, margin, y);
                    y += 26;

                    // Table header
                    double[] colWidths = { 70, 240, 70, 100, 120 }; // Ma, Ten, SL, DonGia, ThanhTien
                    double tableX = margin;
                    double rowHeight = 22;

                    // Draw header background
                    gfx.DrawRectangle(XBrushes.AliceBlue, tableX, y, colWidths.Sum(), rowHeight);
                    // Header text
                    double cx = tableX;
                    gfx.DrawString("Mã sách", boldFont, black, new XRect(cx + 4, y + 4, colWidths[0] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[0];
                    gfx.DrawString("Tên sách", boldFont, black, new XRect(cx + 4, y + 4, colWidths[1] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[1];
                    gfx.DrawString("SL", boldFont, black, new XRect(cx + 4, y + 4, colWidths[2] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[2];
                    gfx.DrawString("Đơn giá", boldFont, black, new XRect(cx + 4, y + 4, colWidths[3] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[3];
                    gfx.DrawString("Thành tiền", boldFont, black, new XRect(cx + 4, y + 4, colWidths[4] - 8, rowHeight), XStringFormats.TopLeft);
                    y += rowHeight;

                    // Rows
                    decimal rawTotal = 0m;
                    foreach (DataRow row in dtGioHang.Rows)
                    {
                        int ma = row.Field<int>("MaSach");
                        string ten = row.Field<string>("TenSach");
                        int sl = row.Field<int>("SoLuong");
                        decimal gia = row.Field<decimal>("DonGia");
                        decimal tt = row.Field<decimal>("ThanhTien");
                        rawTotal += tt;

                        // Alternating background
                        if ((((int)((y - margin) / rowHeight)) % 2) == 1)
                            gfx.DrawRectangle(XBrushes.WhiteSmoke, tableX, y, colWidths.Sum(), rowHeight);

                        // Grid lines
                        gfx.DrawRectangle(gridPen, tableX, y, colWidths.Sum(), rowHeight);

                        // Text
                        cx = tableX;
                        gfx.DrawString(ma.ToString(), normalFont, black, new XRect(cx + 4, y + 4, colWidths[0] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[0];
                        gfx.DrawString(ten, normalFont, black, new XRect(cx + 4, y + 4, colWidths[1] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[1];
                        gfx.DrawString(sl.ToString(), normalFont, black, new XRect(cx + 4, y + 4, colWidths[2] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[2];
                        gfx.DrawString(string.Format("{0:N0} VNĐ", gia), normalFont, black, new XRect(cx + 4, y + 4, colWidths[3] - 8, rowHeight), XStringFormats.TopLeft); cx += colWidths[3];
                        gfx.DrawString(string.Format("{0:N0} VNĐ", tt), normalFont, black, new XRect(cx + 4, y + 4, colWidths[4] - 8, rowHeight), XStringFormats.TopLeft);

                        y += rowHeight;

                        // Page break if near bottom
                        if (y > page.Height - margin - 160)
                        {
                            // Totals will be on next page; add new page
                            page = document.AddPage();
                            page.Size = PdfSharp.PageSize.A4;
                            gfx = XGraphics.FromPdfPage(page);
                            y = margin;
                        }
                    }

                    // Totals
                    decimal afterDiscount = rawTotal - currentDiscount;
                    if (afterDiscount < 0) afterDiscount = 0;
                    decimal vatAmount = currentVatPercent > 0 ? Math.Round(afterDiscount * (currentVatPercent / 100m), 0) : 0m;
                    decimal payable = afterDiscount + vatAmount;

                    y += 16;
                    gfx.DrawString($"Tạm tính: {rawTotal:N0} VNĐ", normalFont, black, margin, y); y += 18;
                    gfx.DrawString($"Giảm giá: {currentDiscount:N0} VNĐ", normalFont, black, margin, y); y += 18;
                    gfx.DrawString($"VAT ({currentVatPercent:N0}%): {vatAmount:N0} VNĐ", normalFont, black, margin, y); y += 22;
                    gfx.DrawString($"Tổng tiền phải trả: {payable:N0} VNĐ", boldFont, black, margin, y);

                    // Footer
                    y += 28;
                    gfx.DrawString("Cảm ơn quý khách!", normalFont, black, margin, y);

                    document.Save(fullPath);
                }

                // Open the PDF
                System.Diagnostics.Process.Start(fullPath);
                MessageBox.Show($"Đã xuất hóa đơn: {fullPath}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
