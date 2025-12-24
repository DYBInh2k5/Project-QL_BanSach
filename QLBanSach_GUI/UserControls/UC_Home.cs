using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLBanSach_DAL;

namespace QLBanSach_GUI.UserControls
{
    public partial class UC_Home : UserControl
    {
        // Cache: doanh thu theo tháng theo năm
        private readonly Dictionary<int, DataTable> _monthlyCacheByYear = new Dictionary<int, DataTable>();

        private bool _initialized;

        public UC_Home()
        {
            InitializeComponent();
            this.Load += UC_Home_Load;

            // wire one-time events here to avoid multiple subscriptions
            btnRefreshAll.Click += (s, args) => { _monthlyCacheByYear.Clear(); ReloadAll(); };
            cbYear.SelectedIndexChanged += (s, args) => LoadChartDoanhThu(GetSelectedYear());
            numTop.ValueChanged += (s, args) => ReloadTopAndHeatmap();
            btnApplyRange.Click += (s, args) => ReloadTopAndHeatmap();
            dtFrom.ValueChanged += (s, args) => { if (chkUseRange.Checked) ReloadTopAndHeatmap(); };
            dtTo.ValueChanged += (s, args) => { if (chkUseRange.Checked) ReloadTopAndHeatmap(); };
            chkUseRange.CheckedChanged += (s, args) => ReloadTopAndHeatmap();
            dgvTopSach.CellDoubleClick += dgvTopSach_CellDoubleClick;
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            if (_initialized) return;
            _initialized = true;

            lblChao.Text = "📚 Xin chào, chúc bạn một ngày làm việc hiệu quả!";
            PopulateYears();
            ReloadAll();
        }

        private void ReloadAll()
        {
            LoadThongKeTong();
            LoadChartDoanhThu(GetSelectedYear());
            LoadChartDoanhThuNam();
            ReloadTopAndHeatmap();
            StyleGrids();
            StyleCharts();
        }

        private void ReloadTopAndHeatmap()
        {
            LoadTopSach((int)numTop.Value);
            LoadHeatmap();
        }

        private int GetSelectedYear()
        {
            if (cbYear.SelectedItem is int y) return y;
            int current = DateTime.Now.Year;
            if (cbYear.Items.Count == 0) cbYear.Items.Add(current);
            cbYear.SelectedItem = current;
            return current;
        }

        private void PopulateYears()
        {
            try
            {
                var dt = DatabaseHelper.ExecuteQuery("SELECT DISTINCT YEAR(NgayLap) AS Nam FROM HoaDon ORDER BY Nam DESC");
                cbYear.Items.Clear();
                foreach (DataRow r in dt.Rows)
                    cbYear.Items.Add(Convert.ToInt32(r["Nam"]));
                if (cbYear.Items.Count == 0) cbYear.Items.Add(DateTime.Now.Year);
                cbYear.SelectedIndex = 0;

                // Gợi ý range mặc định
                var y = DateTime.Now.Year;
                dtFrom.Value = new DateTime(y, 1, 1);
                dtTo.Value = DateTime.Today;

                if (numTop.Value < 3) numTop.Value = 10;
            }
            catch
            {
                cbYear.Items.Clear();
                cbYear.Items.Add(DateTime.Now.Year);
                cbYear.SelectedIndex = 0;
            }
        }

        // Thống kê tổng
        private void LoadThongKeTong()
        {
            try
            {
                object oSach = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Sach");
                lblSach.Text = (oSach == null || oSach == DBNull.Value) ? "0" : oSach.ToString();

                object oKhach = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM KhachHang");
                lblKhach.Text = (oKhach == null || oKhach == DBNull.Value) ? "0" : oKhach.ToString();

                object oHD = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM HoaDon");
                lblHoaDon.Text = (oHD == null || oHD == DBNull.Value) ? "0" : oHD.ToString();

                object oDT = DatabaseHelper.ExecuteScalar("SELECT SUM(TongTien) FROM HoaDon");
                lblDoanhThu.Text = (oDT == null || oDT == DBNull.Value)
                    ? "0 VNĐ"
                    : string.Format("{0:N0} VNĐ", Convert.ToDecimal(oDT));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê tổng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Biểu đồ doanh thu theo tháng (có cache theo năm)
        private void LoadChartDoanhThu(int year)
        {
            try
            {
                DataTable dt;
                if (!_monthlyCacheByYear.TryGetValue(year, out dt))
                {
                    string sql = @"
                        SELECT MONTH(NgayLap) AS Thang, ISNULL(SUM(TongTien),0) AS Tong
                        FROM HoaDon
                        WHERE YEAR(NgayLap) = @y
                        GROUP BY MONTH(NgayLap)
                        ORDER BY MONTH(NgayLap)";
                    dt = DatabaseHelper.ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@y", year) });
                    _monthlyCacheByYear[year] = dt;
                }

                chartDoanhThu.Series.Clear();
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Titles.Add($"Doanh thu theo tháng ({year})");

                var s = new Series("DoanhThu")
                {
                    ChartType = SeriesChartType.Column,
                    XValueMember = "Thang",
                    YValueMembers = "Tong",
                    IsValueShownAsLabel = true
                };
                chartDoanhThu.Series.Add(s);
                chartDoanhThu.DataSource = dt;
                chartDoanhThu.DataBind();

                var area = chartDoanhThu.ChartAreas.Count > 0 ? chartDoanhThu.ChartAreas[0] : chartDoanhThu.ChartAreas.Add("Main");
                area.AxisX.Title = "Tháng";
                area.AxisY.Title = "Doanh thu";
                area.AxisX.Interval = 1;
                area.AxisY.LabelStyle.Format = "#,##0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ tháng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Biểu đồ doanh thu theo năm
        private void LoadChartDoanhThuNam()
        {
            try
            {
                string sql = @"
                    SELECT YEAR(NgayLap) AS Nam, ISNULL(SUM(TongTien),0) AS Tong
                    FROM HoaDon
                    GROUP BY YEAR(NgayLap)
                    ORDER BY YEAR(NgayLap)";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                chartDoanhThuNam.Series.Clear();
                chartDoanhThuNam.Titles.Clear();
                chartDoanhThuNam.Titles.Add("Doanh thu theo năm");

                var series = new Series("DoanhThuNam")
                {
                    ChartType = SeriesChartType.Line,
                    XValueMember = "Nam",
                    YValueMembers = "Tong",
                    IsValueShownAsLabel = true,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 7
                };
                chartDoanhThuNam.Series.Add(series);
                chartDoanhThuNam.DataSource = dt;
                chartDoanhThuNam.DataBind();

                var area = chartDoanhThuNam.ChartAreas.Count > 0 ? chartDoanhThuNam.ChartAreas[0] : chartDoanhThuNam.ChartAreas.Add("Main");
                area.AxisX.Title = "Năm";
                area.AxisY.Title = "Doanh thu";
                area.AxisX.Interval = 1;
                area.AxisY.LabelStyle.Format = "#,##0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ năm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Top sách (lọc theo DateRange nếu bật)
        private void LoadTopSach(int topN)
        {
            try
            {
                var pars = new List<SqlParameter> { new SqlParameter("@top", topN) }; // FIXED

                string where = "";
                if (ShouldUseRange(out DateTime from, out DateTime to))
                {
                    where = " AND h.NgayLap >= @from AND h.NgayLap < @toPlusOne";
                    pars.Add(new SqlParameter("@from", from.Date));
                    pars.Add(new SqlParameter("@toPlusOne", to.Date.AddDays(1))); // inclusive
                }

                string sql = $@"
                    SELECT TOP (@top) s.MaSach, s.TenSach, ISNULL(SUM(c.SoLuong),0) AS DaBan
                    FROM ChiTietHoaDon c
                    JOIN HoaDon h ON h.MaHD = c.MaHD
                    JOIN Sach s ON c.MaSach = s.MaSach
                    WHERE 1=1 {where}
                    GROUP BY s.MaSach, s.TenSach
                    ORDER BY DaBan DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, pars.ToArray());
                dgvTopSach.DataSource = dt;

                if (dgvTopSach.Columns.Contains("MaSach"))
                    dgvTopSach.Columns["MaSach"].HeaderText = "Mã sách";
                if (dgvTopSach.Columns.Contains("TenSach"))
                    dgvTopSach.Columns["TenSach"].HeaderText = "Tên sách";
                if (dgvTopSach.Columns.Contains("DaBan"))
                {
                    dgvTopSach.Columns["DaBan"].HeaderText = "Đã bán";
                    dgvTopSach.Columns["DaBan"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Top sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Heatmap (thống kê theo thể loại, có DateRange)
        private void LoadHeatmap()
        {
            try
            {
                var pars = new List<SqlParameter>(); // FIXED

                string where = "";
                if (ShouldUseRange(out DateTime from, out DateTime to))
                {
                    where = " AND h.NgayLap >= @from AND h.NgayLap < @toPlusOne";
                    pars.Add(new SqlParameter("@from", from.Date));
                    pars.Add(new SqlParameter("@toPlusOne", to.Date.AddDays(1)));
                }

                string sql = $@"
                    SELECT s.TheLoai, ISNULL(SUM(c.SoLuong),0) AS TongBan
                    FROM ChiTietHoaDon c
                    JOIN HoaDon h ON h.MaHD = c.MaHD
                    JOIN Sach s ON c.MaSach = s.MaSach
                    WHERE 1=1 {where}
                    GROUP BY s.TheLoai
                    ORDER BY TongBan DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, pars.ToArray());
                dgvHeatmap.DataSource = dt;

                if (dgvHeatmap.Columns.Contains("TheLoai"))
                    dgvHeatmap.Columns["TheLoai"].HeaderText = "Thể loại";
                if (dgvHeatmap.Columns.Contains("TongBan"))
                {
                    dgvHeatmap.Columns["TongBan"].HeaderText = "Tổng bán";
                    dgvHeatmap.Columns["TongBan"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Heatmap: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ShouldUseRange(out DateTime from, out DateTime to)
        {
            from = dtFrom.Value.Date;
            to = dtTo.Value.Date;
            if (!chkUseRange.Checked) return false;
            if (to < from) { var tmp = from; from = to; to = tmp; }
            return true;
        }

        private void StyleCharts()
        {
            try
            {
                foreach (var ch in new[] { chartDoanhThu, chartDoanhThuNam })
                {
                    if (ch.ChartAreas.Count == 0) continue;
                    var a = ch.ChartAreas[0];
                    a.AxisX.MajorGrid.Enabled = false;
                    a.AxisY.MajorGrid.LineColor = Color.Gainsboro;
                    a.BackColor = Color.White;
                }
            }
            catch { }
        }

        private void StyleGrids()
        {
            try
            {
                foreach (var g in new DataGridView[] { dgvTopSach, dgvHeatmap })
                {
                    g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    g.ReadOnly = true;
                    g.RowHeadersVisible = false;
                }
            }
            catch { }
        }

        // Drill-down: double-click Top sách -> chi tiết hóa đơn chứa sách
        private void dgvTopSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTopSach.Rows[e.RowIndex];
            if (!dgvTopSach.Columns.Contains("MaSach")) return;
            if (!int.TryParse(row.Cells["MaSach"]?.Value?.ToString(), out var maSach)) return;
            ShowBookInvoiceDetails(maSach);
        }

        private void ShowBookInvoiceDetails(int maSach)
        {
            try
            {
                var pars = new List<SqlParameter> { new SqlParameter("@ms", maSach) };
                string where = "";
                if (ShouldUseRange(out DateTime from, out DateTime to))
                {
                    where = " AND h.NgayLap >= @from AND h.NgayLap < @toPlusOne";
                    pars.Add(new SqlParameter("@from", from.Date));
                    pars.Add(new SqlParameter("@toPlusOne", to.Date.AddDays(1)));
                }

                string sql = $@"
                    SELECT h.MaHD, h.NgayLap, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien
                    FROM ChiTietHoaDon c
                    JOIN HoaDon h ON h.MaHD = c.MaHD
                    WHERE c.MaSach = @ms {where}
                    ORDER BY h.NgayLap DESC, h.MaHD DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, pars.ToArray());

                using (var f = new Form())
                using (var grid = new DataGridView())
                using (var lbl = new Label())
                {
                    f.Text = $"Chi tiết hóa đơn - Mã sách {maSach}";
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.Size = new Size(800, 500);

                    lbl.Dock = DockStyle.Top;
                    lbl.Height = 28;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                    lbl.Padding = new Padding(8);

                    grid.Dock = DockStyle.Fill;
                    grid.ReadOnly = true;
                    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    grid.RowHeadersVisible = false;
                    grid.DataSource = dt;

                    if (grid.Columns.Contains("NgayLap"))
                        grid.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    if (grid.Columns.Contains("DonGia"))
                        grid.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    if (grid.Columns.Contains("ThanhTien"))
                        grid.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                    decimal tong = 0; int sl = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        sl += Convert.ToInt32(r["SoLuong"]);
                        tong += Convert.ToDecimal(r["ThanhTien"]);
                    }
                    lbl.Text = $"Số dòng: {dt.Rows.Count} | Tổng SL: {sl:N0} | Doanh thu: {tong:N0}";

                    f.Controls.Add(grid);
                    f.Controls.Add(lbl);
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi drill-down: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cardSach_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
