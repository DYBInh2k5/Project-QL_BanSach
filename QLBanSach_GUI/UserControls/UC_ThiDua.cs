using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_ThiDua : UserControl
    {
        private readonly string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";

        public UC_ThiDua()
        {
            InitializeComponent();
            this.btnRefresh.Click += (s, e) => LoadLeaderboard();
            this.cboPeriod.SelectedIndexChanged += (s, e) => LoadLeaderboard();
            this.btnExportPdf.Click += btnExportPdf_Click; // NEW
        }

        private void UC_ThiDua_Load(object sender, EventArgs e)
        {
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            try
            {
                string where = "";
                var now = DateTime.Now;
                var period = cboPeriod.SelectedItem?.ToString() ?? "Tất cả";
                if (period == "Tháng này")
                    where = "WHERE MONTH(hd.NgayLap) = @m AND YEAR(hd.NgayLap) = @y";
                else if (period == "Năm nay")
                    where = "WHERE YEAR(hd.NgayLap) = @y";

                string sql = $@"
                    SELECT 
                        nv.MaNV,
                        nv.HoTen,
                        SUM(ct.SoLuong) AS TongSachBan,
                        SUM(ct.ThanhTien) AS TongDoanhThu
                    FROM HoaDon hd
                    INNER JOIN NhanVien nv ON nv.MaNV = hd.MaNV
                    INNER JOIN ChiTietHoaDon ct ON ct.MaHD = hd.MaHD
                    {where}
                    GROUP BY nv.MaNV, nv.HoTen
                    ORDER BY TongSachBan DESC, TongDoanhThu DESC";

                var dt = new DataTable();
                using (var conn = new SqlConnection(_connectionString))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    if (where.Contains("@m")) da.SelectCommand.Parameters.AddWithValue("@m", now.Month);
                    if (where.Contains("@y")) da.SelectCommand.Parameters.AddWithValue("@y", now.Year);
                    da.Fill(dt);
                }

                dgvLeaderboard.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    var top = dt.Rows[0];
                    lblTopEmployee.Text =
                        $"Top: {top["HoTen"]} (Mã: {top["MaNV"]}) — Sách bán: {top["TongSachBan"]}, Doanh thu: {Convert.ToDecimal(top["TongDoanhThu"]):N0} VNĐ";
                }
                else
                {
                    lblTopEmployee.Text = "Top: (chưa có dữ liệu)";
                }

                if (dgvLeaderboard.Columns["MaNV"] != null) dgvLeaderboard.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvLeaderboard.Columns["HoTen"] != null) dgvLeaderboard.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvLeaderboard.Columns["TongSachBan"] != null) dgvLeaderboard.Columns["TongSachBan"].HeaderText = "Tổng sách bán";
                if (dgvLeaderboard.Columns["TongDoanhThu"] != null) dgvLeaderboard.Columns["TongDoanhThu"].HeaderText = "Tổng doanh thu (VNĐ)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thi đua: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NEW: Export leaderboard to PDF
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog
                {
                    Title = "Xuất bảng thi đua (PDF)",
                    Filter = "PDF|*.pdf",
                    FileName = $"ThiDua_NhanVien_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var doc = new PdfDocument();
                    var page = doc.AddPage();
                    var gfx = XGraphics.FromPdfPage(page);

                    double margin = 40;
                    double y = margin;
                    var fontTitle = new XFont("Segoe UI", 16, XFontStyle.Bold);
                    var fontSub = new XFont("Segoe UI", 10, XFontStyle.Regular);

                    // Title
                    gfx.DrawString("BẢNG THI ĐUA NHÂN VIÊN BÁN NHIỀU SÁCH", fontTitle, XBrushes.Black, new XRect(0, y, page.Width, 24), XStringFormats.TopCenter);
                    y += 32;

                    // Period info
                    string periodText = cboPeriod.SelectedItem?.ToString() ?? "Tất cả";
                    gfx.DrawString("Kỳ thống kê: " + periodText, fontSub, XBrushes.Black, margin, y);
                    y += 18;

                    // Top summary
                    gfx.DrawString(lblTopEmployee.Text, fontSub, XBrushes.Black, margin, y);
                    y += 18;

                    // Header line
                    gfx.DrawLine(XPens.Gray, margin, y, page.Width - margin, y);
                    y += 10;

                    // Table header
                    gfx.DrawString("Mã NV", fontSub, XBrushes.Black, margin, y);
                    gfx.DrawString("Họ tên", fontSub, XBrushes.Black, margin + 90, y);
                    gfx.DrawString("Tổng sách", fontSub, XBrushes.Black, margin + 300, y);
                    gfx.DrawString("Doanh thu", fontSub, XBrushes.Black, margin + 400, y);
                    y += 14;
                    gfx.DrawLine(XPens.Gray, margin, y, page.Width - margin, y);
                    y += 8;

                    // Rows from DataGridView
                    foreach (DataGridViewRow row in dgvLeaderboard.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string maNV = Convert.ToString(row.Cells["MaNV"].Value);
                        string hoTen = Convert.ToString(row.Cells["HoTen"].Value);
                        string tongSach = Convert.ToString(row.Cells["TongSachBan"].Value);
                        string doanhThu = "";
                        var val = row.Cells["TongDoanhThu"].Value;
                        if (val != null && val != DBNull.Value)
                        {
                            try { doanhThu = Convert.ToDecimal(val).ToString("N0"); }
                            catch { doanhThu = Convert.ToString(val); }
                        }

                        gfx.DrawString(maNV, fontSub, XBrushes.Black, margin, y);
                        gfx.DrawString(hoTen, fontSub, XBrushes.Black, margin + 90, y);
                        gfx.DrawString(tongSach, fontSub, XBrushes.Black, margin + 300, y);
                        gfx.DrawString(doanhThu, fontSub, XBrushes.Black, margin + 400, y);
                        y += 16;

                        if (y > page.Height - margin - 20)
                        {
                            page = doc.AddPage();
                            gfx.Dispose();
                            gfx = XGraphics.FromPdfPage(page);
                            y = margin;
                        }
                    }

                    doc.Save(sfd.FileName);
                    doc.Close();
                    MessageBox.Show("Xuất PDF thi đua thành công!\n" + sfd.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
