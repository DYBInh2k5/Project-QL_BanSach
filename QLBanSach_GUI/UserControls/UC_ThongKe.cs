using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_ThongKe : UserControl
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBanSach;Integrated Security=True";

        public UC_ThongKe()
        {
            InitializeComponent();
            // ensure Load handler runs to populate totals and category chart
            this.Load += UC_ThongKe_Load;

            // wire leaderboard events
            cboPeriod.SelectedIndexChanged += (s, e) => LoadLeaderboard();
            btnRefreshLeaderboard.Click += (s, e) => LoadLeaderboard();
            // existing events
            btnNgay.Click += btnNgay_Click;
            btnTuan.Click += btnTuan_Click;
            btnThang.Click += btnThang_Click;
            cbLoaiBieuDo.SelectedIndexChanged += cbLoaiBieuDo_SelectedIndexChanged;
            btnXuatPDF.Click += btnXuatPDF_Click;
            // wire events trong ctor
            cbThongKePhu.SelectedIndexChanged += (s, e) => LoadThongKePhu();
            btnRefreshPhu.Click += (s, e) => LoadThongKePhu();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadPieTheLoai();
            dtpChonNgay.Value = DateTime.Now;
            LoadLeaderboard();
        }

        // EXISTING: Revenue charts and helpers (unchanged)
        private void LoadThongKe()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            MONTH(NgayLap) AS Thang, 
                            SUM(TongTien) AS TongDoanhThu, 
                            COUNT(MaHD) AS SoHoaDon
                        FROM HoaDon
                        GROUP BY MONTH(NgayLap)
                        ORDER BY Thang";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                chartDoanhThu.Series.Clear();
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Titles.Add("Biểu đồ doanh thu theo tháng");
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";

                Series series = new Series("Doanh thu");
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.CornflowerBlue;
                series.BorderWidth = 3;
                series.IsValueShownAsLabel = true;
                series.LabelForeColor = Color.DarkBlue;
                series.Font = new Font("Segoe UI", 8, FontStyle.Bold);

                decimal tongTien = 0;
                int tongHD = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int thang = Convert.ToInt32(row["Thang"]);
                    decimal doanhThu = Convert.ToDecimal(row["TongDoanhThu"]);
                    int soHD = Convert.ToInt32(row["SoHoaDon"]);
                    series.Points.AddXY($"Tháng {thang}", doanhThu);
                    tongTien += doanhThu;
                    tongHD += soHD;
                }

                chartDoanhThu.Series.Add(series);
                lblTongHD.Text = $"Tổng hóa đơn: {tongHD}";
                lblTongTien.Text = $"Tổng doanh thu: {tongTien:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VeChart(DataTable dt, string tieuDe)
        {
            chartTK.Series.Clear();
            chartTK.Titles.Clear();
            chartTK.Titles.Add(tieuDe);

            Series s = new Series("Doanh thu");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.Color = Color.DodgerBlue;

            foreach (DataRow r in dt.Rows)
                s.Points.AddXY(r[0].ToString(), r[1]);

            chartTK.Series.Add(s);
        }

        private void btnNgay_Click(object sender, EventArgs e)
        {
            DateTime d = dtpChonNgay.Value;
            string sql = @"
                SELECT CONVERT(varchar(10), NgayLap, 103) AS Ngay, SUM(TongTien) 
                FROM HoaDon 
                WHERE CAST(NgayLap AS DATE) = @day
                GROUP BY CONVERT(varchar(10), NgayLap, 103)";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@day", d.Date);
                da.Fill(dt);
            }

            VeChart(dt, "Doanh thu theo ngày");
            lblTongHD.Text = "Số hóa đơn: " + GetCountHD_ByDay(d);
            lblTongTien.Text = "Doanh thu: " + GetSum_ByDay(d).ToString("N0") + " VNĐ";
        }

        private void btnTuan_Click(object sender, EventArgs e)
        {
            DateTime d = dtpChonNgay.Value;
            string sql = @"
                SELECT 'Tuần ' + CONVERT(varchar, DATEPART(WEEK, NgayLap)) AS Tuan, SUM(TongTien)
                FROM HoaDon
                WHERE DATEPART(WEEK, NgayLap) = DATEPART(WEEK, @d) AND YEAR(NgayLap) = YEAR(@d)
                GROUP BY DATEPART(WEEK, NgayLap)";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@d", d);
                da.Fill(dt);
            }

            VeChart(dt, "Doanh thu theo tuần");
            lblTongHD.Text = "Số hóa đơn: " + GetCountHD_ByWeek(d);
            lblTongTien.Text = "Doanh thu: " + GetSum_ByWeek(d).ToString("N0") + " VNĐ";
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            int thang = dtpChonNgay.Value.Month;
            int nam = dtpChonNgay.Value.Year;

            string sql = @"
                SELECT DAY(NgayLap) AS Ngay, SUM(TongTien) AS DoanhThu
                FROM HoaDon
                WHERE MONTH(NgayLap)=@m AND YEAR(NgayLap)=@y
                GROUP BY DAY(NgayLap)
                ORDER BY Ngay";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@m", thang);
                da.SelectCommand.Parameters.AddWithValue("@y", nam);
                da.Fill(dt);
            }

            VeChart(dt, "Doanh thu theo tháng");
            lblTongHD.Text = "Số hóa đơn: " + GetCountHD_ByMonth(thang, nam);
            lblTongTien.Text = "Doanh thu: " + GetSum_ByMonth(thang, nam).ToString("N0") + " VNĐ";
        }

        private int GetCountHD_ByDay(DateTime d)
        {
            string sql = "SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayLap AS DATE)=@d";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@d", d.Date);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private decimal GetSum_ByDay(DateTime d)
        {
            string sql = "SELECT SUM(TongTien) FROM HoaDon WHERE CAST(NgayLap AS DATE)=@d";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@d", d.Date);
                conn.Open();
                object kq = cmd.ExecuteScalar();
                return kq == DBNull.Value ? 0 : Convert.ToDecimal(kq);
            }
        }

        private int GetCountHD_ByWeek(DateTime d)
        {
            string sql = @"
                SELECT COUNT(*) FROM HoaDon 
                WHERE DATEPART(WEEK, NgayLap)=DATEPART(WEEK,@d) AND YEAR(NgayLap)=YEAR(@d)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@d", d);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private decimal GetSum_ByWeek(DateTime d)
        {
            string sql = @"
                SELECT SUM(TongTien) FROM HoaDon 
                WHERE DATEPART(WEEK, NgayLap)=DATEPART(WEEK,@d) AND YEAR(NgayLap)=YEAR(@d)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@d", d);
                conn.Open();
                object kq = cmd.ExecuteScalar();
                return kq == DBNull.Value ? 0 : Convert.ToDecimal(kq);
            }
        }

        private int GetCountHD_ByMonth(int m, int y)
        {
            string sql = "SELECT COUNT(*) FROM HoaDon WHERE MONTH(NgayLap)=@m AND YEAR(NgayLap)=@y";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@m", m);
                cmd.Parameters.AddWithValue("@y", y);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private decimal GetSum_ByMonth(int m, int y)
        {
            string sql = "SELECT SUM(TongTien) FROM HoaDon WHERE MONTH(NgayLap)=@m AND YEAR(NgayLap)=@y";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@m", m);
                cmd.Parameters.AddWithValue("@y", y);
                conn.Open();
                object kq = cmd.ExecuteScalar();
                return kq == DBNull.Value ? 0 : Convert.ToDecimal(kq);
            }
        }

        // NEW: Leaderboard logic
        private void LoadLeaderboard()
        {
            try
            {
                string where = "";
                var now = DateTime.Now;
                var selected = cboPeriod.SelectedItem?.ToString() ?? "Tất cả";
                if (selected == "Tháng này")
                    where = "WHERE MONTH(hd.NgayLap) = @m AND YEAR(hd.NgayLap) = @y";
                else if (selected == "Năm nay")
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

                DataTable dt = new DataTable();
                using (var conn = new SqlConnection(connectionString))
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

                // headers
                if (dgvLeaderboard.Columns["MaNV"] != null) dgvLeaderboard.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvLeaderboard.Columns["HoTen"] != null) dgvLeaderboard.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvLeaderboard.Columns["TongSachBan"] != null) dgvLeaderboard.Columns["TongSachBan"].HeaderText = "Tổng sách bán";
                if (dgvLeaderboard.Columns["TongDoanhThu"] != null) dgvLeaderboard.Columns["TongDoanhThu"].HeaderText = "Tổng doanh thu (VNĐ)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng thi đua: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // EXISTING: Export PDF, extended to include leaderboard
        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog
                {
                    Title = "Xuất báo cáo thống kê (PDF)",
                    Filter = "PDF|*.pdf",
                    FileName = $"BaoCaoThongKe_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var doc = new PdfDocument();
                    var page = doc.AddPage();
                    var gfx = XGraphics.FromPdfPage(page);

                    double margin = 40;
                    double y = margin;
                    double contentWidth = page.Width - margin * 2;

                    var fontTitle = new XFont("Segoe UI", 16, XFontStyle.Bold);
                    var fontSub = new XFont("Segoe UI", 10, XFontStyle.Regular);

                    gfx.DrawString("BÁO CÁO THỐNG KÊ DOANH THU", fontTitle, XBrushes.Black, new XRect(0, y, page.Width, 24), XStringFormats.TopCenter);
                    y += 32;

                    gfx.DrawString("Thời gian xuất: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"), fontSub, XBrushes.Black, margin, y);
                    y += 18;
                    gfx.DrawString(lblTongHD.Text, fontSub, XBrushes.Black, margin, y);
                    y += 18;
                    gfx.DrawString(lblTongTien.Text, fontSub, XBrushes.Black, margin, y);
                    y += 14;

                    gfx.DrawLine(XPens.Gray, margin, y, page.Width - margin, y);
                    y += 12;

                    void DrawChart(string title, System.Windows.Forms.DataVisualization.Charting.Chart chart)
                    {
                        bool hasData = false;
                        foreach (var s in chart.Series)
                        {
                            if (s.Points != null && s.Points.Count > 0) { hasData = true; break; }
                        }
                        if (!hasData) return;

                        gfx.DrawString(title, new XFont("Segoe UI", 12, XFontStyle.Bold), XBrushes.Black, margin, y);
                        y += 22;

                        byte[] pngBytes;
                        using (var ms = new MemoryStream())
                        {
                            chart.SaveImage(ms, ChartImageFormat.Png);
                            pngBytes = ms.ToArray();
                        }
                        using (var msImg = new MemoryStream(pngBytes))
                        using (var ximg = XImage.FromStream(msImg))
                        {
                            double scale = contentWidth / ximg.PointWidth;
                            double drawW = ximg.PointWidth * scale;
                            double drawH = ximg.PointHeight * scale;

                            if (y + drawH > page.Height - margin)
                            {
                                page = doc.AddPage();
                                gfx.Dispose();
                                gfx = XGraphics.FromPdfPage(page);
                                y = margin;
                            }

                            gfx.DrawImage(ximg, margin, y, drawW, drawH);
                            y += drawH + 18;
                        }
                    }

                    // charts
                    DrawChart("Biểu đồ doanh thu theo tháng", chartDoanhThu);
                    DrawChart("Biểu đồ theo lựa chọn (Ngày/Tuần/Tháng)", chartTK);
                    DrawChart("Doanh thu theo thể loại", chartTheLoai);

                    // Leaderboard section
                    gfx.DrawString("Thi đua: Nhân viên bán nhiều sách", new XFont("Segoe UI", 12, XFontStyle.Bold), XBrushes.Black, margin, y);
                    y += 22;

                    // Top employee line
                    gfx.DrawString(lblTopEmployee.Text, fontSub, XBrushes.Black, margin, y);
                    y += 18;

                    // Table header
                    gfx.DrawString("Mã NV", fontSub, XBrushes.Black, margin, y);
                    gfx.DrawString("Họ tên", fontSub, XBrushes.Black, margin + 90, y);
                    gfx.DrawString("Tổng sách", fontSub, XBrushes.Black, margin + 300, y);
                    gfx.DrawString("Doanh thu", fontSub, XBrushes.Black, margin + 400, y);
                    y += 14;
                    gfx.DrawLine(XPens.Gray, margin, y, page.Width - margin, y);
                    y += 8;

                    // Rows
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
                            try { doanhThu = Convert.ToDecimal(val).ToString("N0"); } catch { doanhThu = Convert.ToString(val); }
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
                    MessageBox.Show("Xuất PDF thành công!\n" + sfd.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPieTheLoai()
        {
            chartTheLoai.Series.Clear();
            chartTheLoai.Titles.Clear();
            chartTheLoai.Titles.Add("Doanh thu theo thể loại sách");

            Series series = new Series("Thể loại");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    s.TheLoai,
                    SUM(ct.ThanhTien) AS DoanhThu
                FROM ChiTietHoaDon ct
                JOIN Sach s ON ct.MaSach = s.MaSach
                GROUP BY s.TheLoai";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(row["TheLoai"].ToString(), row["DoanhThu"]);
            }

            chartTheLoai.Series.Add(series);
        }

        private void LoadBieuDo(string loai)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("Thống kê doanh thu");

            Series series = new Series("Doanh thu");
            series.IsValueShownAsLabel = true;

            switch (loai)
            {
                case "Cột": series.ChartType = SeriesChartType.Column; break;
                case "Đường": series.ChartType = SeriesChartType.Line; series.BorderWidth = 3; break;
                case "Tròn": series.ChartType = SeriesChartType.Pie; break;
                case "Vòng": series.ChartType = SeriesChartType.Doughnut; break;
                case "Khu vực": series.ChartType = SeriesChartType.Area; break;
            }

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT MONTH(NgayLap) AS Thang, SUM(TongTien) AS DoanhThu
                    FROM HoaDon
                    GROUP BY MONTH(NgayLap)
                    ORDER BY Thang";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
                series.Points.AddXY("Tháng " + row["Thang"], row["DoanhThu"]);

            chartDoanhThu.Series.Add(series);
        }

        private void cbLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBieuDo(cbLoaiBieuDo.SelectedItem.ToString());
        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {

        }

        // vẽ thống kê phụ dựa trên lựa chọn, hiển thị vào chartTK
        private void LoadThongKePhu()
        {
            try
            {
                string choice = cbThongKePhu.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(choice)) return;

                chartTK.Series.Clear();
                chartTK.Titles.Clear();
                chartTK.ChartAreas[0].AxisX.Interval = 1;
                chartTK.ChartAreas[0].AxisY.LabelStyle.Format = "#,###";

                var series = new Series("Thống kê phụ")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                    Color = Color.SteelBlue,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold)
                };

                DataTable dt = new DataTable();

                using (var conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = null;

                    if (choice == "Số hóa đơn theo tháng")
                    {
                        chartTK.Titles.Add("Số hóa đơn theo tháng");
                        string sql = @"SELECT MONTH(NgayLap) AS Thang, COUNT(MaHD) AS SoHoaDon
                                       FROM HoaDon GROUP BY MONTH(NgayLap) ORDER BY Thang";
                        da = new SqlDataAdapter(sql, conn);
                    }
                    else if (choice == "Top 10 sách bán chạy")
                    {
                        chartTK.Titles.Add("Top 10 sách bán chạy");
                        string sql = @"SELECT TOP 10 s.TenSach, SUM(ct.SoLuong) AS TongSL
                                       FROM ChiTietHoaDon ct
                                       JOIN Sach s ON s.MaSach = ct.MaSach
                                       GROUP BY s.TenSach
                                       ORDER BY TongSL DESC";
                        da = new SqlDataAdapter(sql, conn);
                    }
                    else if (choice == "Doanh thu theo nhân viên")
                    {
                        chartTK.Titles.Add("Doanh thu theo nhân viên");
                        string sql = @"SELECT nv.HoTen, SUM(ct.ThanhTien) AS DoanhThu
                                       FROM HoaDon hd
                                       JOIN NhanVien nv ON nv.MaNV = hd.MaNV
                                       JOIN ChiTietHoaDon ct ON ct.MaHD = hd.MaHD
                                       GROUP BY nv.HoTen
                                       ORDER BY DoanhThu DESC";
                        da = new SqlDataAdapter(sql, conn);
                    }
                    else if (choice == "Số lượng theo ngày trong tuần")
                    {
                        chartTK.Titles.Add("Số lượng theo ngày trong tuần");
                        string sql = @"SELECT DATEPART(WEEKDAY, hd.NgayLap) AS Thu, SUM(ct.SoLuong) AS TongSL
                                       FROM HoaDon hd
                                       JOIN ChiTietHoaDon ct ON ct.MaHD = hd.MaHD
                                       GROUP BY DATEPART(WEEKDAY, hd.NgayLap)
                                       ORDER BY Thu";
                        da = new SqlDataAdapter(sql, conn);
                    }

                    if (da == null) return;
                    da.Fill(dt);
                }

                // map dữ liệu lên series
                if (dt.Columns.Count >= 2)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string x;
                        decimal y;

                        if (cbThongKePhu.SelectedItem?.ToString() == "Số lượng theo ngày trong tuần")
                        {
                            // SQL Server mặc định WEEKDAY: 1=Chủ nhật, 2=Thứ 2, ...
                            int thu = Convert.ToInt32(row[0]);
                            string[] labels = { "CN", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
                            x = labels[(thu - 1 + 7) % 7];
                            y = Convert.ToDecimal(row[1]);
                        }
                        else if (cbThongKePhu.SelectedItem?.ToString() == "Số hóa đơn theo tháng")
                        {
                            x = "Tháng " + row[0].ToString();
                            y = Convert.ToDecimal(row[1]);
                        }
                        else
                        {
                            x = row[0].ToString();
                            y = Convert.ToDecimal(row[1]);
                        }

                        series.Points.AddXY(x, y);
                    }
                }

                chartTK.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê phụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTongHD_Click(object sender, EventArgs e)
        {

        }

        private void chartTheLoai_Click(object sender, EventArgs e)
        {

        }
    }
}
