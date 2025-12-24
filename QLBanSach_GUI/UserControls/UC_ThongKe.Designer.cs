namespace QLBanSach_GUI.UserControls
{
    partial class UC_ThongKe
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongHD;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongTien;
        private Guna.UI2.WinForms.Guna2Button btnNgay;
        private Guna.UI2.WinForms.Guna2Button btnTuan;
        private Guna.UI2.WinForms.Guna2Button btnThang;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpChonNgay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTK;
        private Guna.UI2.WinForms.Guna2ComboBox cbLoaiBieuDo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTheLoai;
        private Guna.UI2.WinForms.Guna2Button btnXuatPDF;

        // NEW: Leaderboard UI
        private System.Windows.Forms.SplitContainer splitRoot;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpLeaderboard;
        private System.Windows.Forms.DataGridView dgvLeaderboard;
        private System.Windows.Forms.FlowLayoutPanel flowLeaderboardTop;
        private System.Windows.Forms.Label lblTopEmployee;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.Button btnRefreshLeaderboard;

        // NEW: Additional Statistics Controls
        private Guna.UI2.WinForms.Guna2ComboBox cbThongKePhu;
        private Guna.UI2.WinForms.Guna2Button btnRefreshPhu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitRoot = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTongHD = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTongTien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnNgay = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuan = new Guna.UI2.WinForms.Guna2Button();
            this.btnThang = new Guna.UI2.WinForms.Guna2Button();
            this.dtpChonNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.chartTK = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbLoaiBieuDo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chartTheLoai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnXuatPDF = new Guna.UI2.WinForms.Guna2Button();
            this.cbThongKePhu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnRefreshPhu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpLeaderboard = new System.Windows.Forms.GroupBox();
            this.dgvLeaderboard = new System.Windows.Forms.DataGridView();
            this.flowLeaderboardTop = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshLeaderboard = new System.Windows.Forms.Button();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.lblTopEmployee = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitRoot)).BeginInit();
            this.splitRoot.Panel1.SuspendLayout();
            this.splitRoot.Panel2.SuspendLayout();
            this.splitRoot.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTheLoai)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.grpLeaderboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).BeginInit();
            this.flowLeaderboardTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitRoot
            // 
            this.splitRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRoot.Location = new System.Drawing.Point(0, 0);
            this.splitRoot.Name = "splitRoot";
            // 
            // splitRoot.Panel1
            // 
            this.splitRoot.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitRoot.Panel2
            // 
            this.splitRoot.Panel2.Controls.Add(this.pnlRight);
            this.splitRoot.Size = new System.Drawing.Size(1201, 627);
            this.splitRoot.SplitterDistance = 820;
            this.splitRoot.SplitterWidth = 6;
            this.splitRoot.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.chartDoanhThu);
            this.pnlLeft.Controls.Add(this.lblTongHD);
            this.pnlLeft.Controls.Add(this.lblTongTien);
            this.pnlLeft.Controls.Add(this.btnNgay);
            this.pnlLeft.Controls.Add(this.btnTuan);
            this.pnlLeft.Controls.Add(this.btnThang);
            this.pnlLeft.Controls.Add(this.dtpChonNgay);
            this.pnlLeft.Controls.Add(this.chartTK);
            this.pnlLeft.Controls.Add(this.cbLoaiBieuDo);
            this.pnlLeft.Controls.Add(this.chartTheLoai);
            this.pnlLeft.Controls.Add(this.btnXuatPDF);
            this.pnlLeft.Controls.Add(this.cbThongKePhu);
            this.pnlLeft.Controls.Add(this.btnRefreshPhu);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(8);
            this.pnlLeft.Size = new System.Drawing.Size(820, 627);
            this.pnlLeft.TabIndex = 0;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(8, 37);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(620, 360);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Click += new System.EventHandler(this.chartDoanhThu_Click);
            // 
            // lblTongHD
            // 
            this.lblTongHD.BackColor = System.Drawing.Color.Transparent;
            this.lblTongHD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHD.Location = new System.Drawing.Point(8, 404);
            this.lblTongHD.Name = "lblTongHD";
            this.lblTongHD.Size = new System.Drawing.Size(109, 23);
            this.lblTongHD.TabIndex = 1;
            this.lblTongHD.Text = "Tổng hóa đơn";
            this.lblTongHD.Click += new System.EventHandler(this.lblTongHD_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(8, 434);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(125, 23);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng doanh thu";
            // 
            // btnNgay
            // 
            this.btnNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNgay.ForeColor = System.Drawing.Color.White;
            this.btnNgay.Location = new System.Drawing.Point(640, 8);
            this.btnNgay.Name = "btnNgay";
            this.btnNgay.Size = new System.Drawing.Size(140, 32);
            this.btnNgay.TabIndex = 3;
            this.btnNgay.Text = "Ngày";
            // 
            // btnTuan
            // 
            this.btnTuan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTuan.ForeColor = System.Drawing.Color.White;
            this.btnTuan.Location = new System.Drawing.Point(640, 48);
            this.btnTuan.Name = "btnTuan";
            this.btnTuan.Size = new System.Drawing.Size(140, 32);
            this.btnTuan.TabIndex = 4;
            this.btnTuan.Text = "Tuần";
            // 
            // btnThang
            // 
            this.btnThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThang.ForeColor = System.Drawing.Color.White;
            this.btnThang.Location = new System.Drawing.Point(640, 88);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(140, 32);
            this.btnThang.TabIndex = 5;
            this.btnThang.Text = "Tháng";
            // 
            // dtpChonNgay
            // 
            this.dtpChonNgay.Checked = true;
            this.dtpChonNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpChonNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChonNgay.Location = new System.Drawing.Point(640, 128);
            this.dtpChonNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpChonNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpChonNgay.Name = "dtpChonNgay";
            this.dtpChonNgay.Size = new System.Drawing.Size(140, 32);
            this.dtpChonNgay.TabIndex = 6;
            this.dtpChonNgay.Value = new System.DateTime(2025, 12, 24, 10, 11, 40, 228);
            // 
            // chartTK
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTK.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTK.Legends.Add(legend2);
            this.chartTK.Location = new System.Drawing.Point(8, 460);
            this.chartTK.Name = "chartTK";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTK.Series.Add(series2);
            this.chartTK.Size = new System.Drawing.Size(380, 170);
            this.chartTK.TabIndex = 7;
            // 
            // cbLoaiBieuDo
            // 
            this.cbLoaiBieuDo.BackColor = System.Drawing.Color.Transparent;
            this.cbLoaiBieuDo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiBieuDo.FocusedColor = System.Drawing.Color.Empty;
            this.cbLoaiBieuDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbLoaiBieuDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbLoaiBieuDo.ItemHeight = 30;
            this.cbLoaiBieuDo.Items.AddRange(new object[] {
            "Cột",
            "Đường",
            "Tròn",
            "Vòng",
            "Khu vực"});
            this.cbLoaiBieuDo.Location = new System.Drawing.Point(634, 283);
            this.cbLoaiBieuDo.Name = "cbLoaiBieuDo";
            this.cbLoaiBieuDo.Size = new System.Drawing.Size(140, 36);
            this.cbLoaiBieuDo.TabIndex = 8;
            // 
            // chartTheLoai
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTheLoai.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTheLoai.Legends.Add(legend3);
            this.chartTheLoai.Location = new System.Drawing.Point(400, 492);
            this.chartTheLoai.Name = "chartTheLoai";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTheLoai.Series.Add(series3);
            this.chartTheLoai.Size = new System.Drawing.Size(380, 138);
            this.chartTheLoai.TabIndex = 9;
            this.chartTheLoai.Click += new System.EventHandler(this.chartTheLoai_Click);
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuatPDF.ForeColor = System.Drawing.Color.White;
            this.btnXuatPDF.Location = new System.Drawing.Point(640, 168);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(140, 32);
            this.btnXuatPDF.TabIndex = 10;
            this.btnXuatPDF.Text = "Xuất PDF";
            // 
            // cbThongKePhu
            // 
            this.cbThongKePhu.BackColor = System.Drawing.Color.Transparent;
            this.cbThongKePhu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbThongKePhu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThongKePhu.FocusedColor = System.Drawing.Color.Empty;
            this.cbThongKePhu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbThongKePhu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbThongKePhu.ItemHeight = 30;
            this.cbThongKePhu.Items.AddRange(new object[] {
            "Số hóa đơn theo tháng",
            "Top 10 sách bán chạy",
            "Doanh thu theo nhân viên",
            "Số lượng theo ngày trong tuần"});
            this.cbThongKePhu.Location = new System.Drawing.Point(400, 432);
            this.cbThongKePhu.Name = "cbThongKePhu";
            this.cbThongKePhu.Size = new System.Drawing.Size(220, 36);
            this.cbThongKePhu.TabIndex = 11;
            // 
            // btnRefreshPhu
            // 
            this.btnRefreshPhu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshPhu.ForeColor = System.Drawing.Color.White;
            this.btnRefreshPhu.Location = new System.Drawing.Point(640, 432);
            this.btnRefreshPhu.Name = "btnRefreshPhu";
            this.btnRefreshPhu.Size = new System.Drawing.Size(140, 32);
            this.btnRefreshPhu.TabIndex = 12;
            this.btnRefreshPhu.Text = "Làm mới TK phụ";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpLeaderboard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(8);
            this.pnlRight.Size = new System.Drawing.Size(375, 627);
            this.pnlRight.TabIndex = 0;
            // 
            // grpLeaderboard
            // 
            this.grpLeaderboard.Controls.Add(this.dgvLeaderboard);
            this.grpLeaderboard.Controls.Add(this.flowLeaderboardTop);
            this.grpLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLeaderboard.Location = new System.Drawing.Point(8, 8);
            this.grpLeaderboard.Name = "grpLeaderboard";
            this.grpLeaderboard.Padding = new System.Windows.Forms.Padding(10);
            this.grpLeaderboard.Size = new System.Drawing.Size(359, 611);
            this.grpLeaderboard.TabIndex = 0;
            this.grpLeaderboard.TabStop = false;
            this.grpLeaderboard.Text = "Thi đua: Nhân viên bán nhiều sách";
            // 
            // dgvLeaderboard
            // 
            this.dgvLeaderboard.AllowUserToAddRows = false;
            this.dgvLeaderboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeaderboard.BackgroundColor = System.Drawing.Color.White;
            this.dgvLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeaderboard.Location = new System.Drawing.Point(10, 63);
            this.dgvLeaderboard.Name = "dgvLeaderboard";
            this.dgvLeaderboard.ReadOnly = true;
            this.dgvLeaderboard.RowHeadersVisible = false;
            this.dgvLeaderboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeaderboard.Size = new System.Drawing.Size(339, 538);
            this.dgvLeaderboard.TabIndex = 0;
            // 
            // flowLeaderboardTop
            // 
            this.flowLeaderboardTop.Controls.Add(this.btnRefreshLeaderboard);
            this.flowLeaderboardTop.Controls.Add(this.cboPeriod);
            this.flowLeaderboardTop.Controls.Add(this.lblTopEmployee);
            this.flowLeaderboardTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLeaderboardTop.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLeaderboardTop.Location = new System.Drawing.Point(10, 23);
            this.flowLeaderboardTop.Name = "flowLeaderboardTop";
            this.flowLeaderboardTop.Size = new System.Drawing.Size(339, 40);
            this.flowLeaderboardTop.TabIndex = 1;
            this.flowLeaderboardTop.WrapContents = false;
            // 
            // btnRefreshLeaderboard
            // 
            this.btnRefreshLeaderboard.Location = new System.Drawing.Point(239, 3);
            this.btnRefreshLeaderboard.Name = "btnRefreshLeaderboard";
            this.btnRefreshLeaderboard.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshLeaderboard.TabIndex = 0;
            this.btnRefreshLeaderboard.Text = "Làm mới";
            // 
            // cboPeriod
            // 
            this.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriod.Items.AddRange(new object[] {
            "Tất cả",
            "Tháng này",
            "Năm nay"});
            this.cboPeriod.Location = new System.Drawing.Point(122, 3);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(111, 21);
            this.cboPeriod.TabIndex = 1;
            // 
            // lblTopEmployee
            // 
            this.lblTopEmployee.AutoSize = true;
            this.lblTopEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTopEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTopEmployee.Location = new System.Drawing.Point(-38, 0);
            this.lblTopEmployee.Name = "lblTopEmployee";
            this.lblTopEmployee.Size = new System.Drawing.Size(154, 19);
            this.lblTopEmployee.TabIndex = 2;
            this.lblTopEmployee.Text = "Top: (chưa có dữ liệu)";
            // 
            // UC_ThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitRoot);
            this.Name = "UC_ThongKe";
            this.Size = new System.Drawing.Size(1201, 627);
            this.splitRoot.Panel1.ResumeLayout(false);
            this.splitRoot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRoot)).EndInit();
            this.splitRoot.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTheLoai)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.grpLeaderboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).EndInit();
            this.flowLeaderboardTop.ResumeLayout(false);
            this.flowLeaderboardTop.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
