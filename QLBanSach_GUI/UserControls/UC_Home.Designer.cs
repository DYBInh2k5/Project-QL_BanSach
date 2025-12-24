namespace QLBanSach_GUI.UserControls
{
    partial class UC_Home
    {
        private System.ComponentModel.IContainer components = null;

        // Top filters
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.NumericUpDown numTop;
        private System.Windows.Forms.CheckBox chkUseRange;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnApplyRange;
        private System.Windows.Forms.Button btnRefreshAll;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChao;

        // Summary strip
        private System.Windows.Forms.FlowLayoutPanel flowSummary;
        private Guna.UI2.WinForms.Guna2Panel cardSach;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSach;
        private System.Windows.Forms.Label capSach;
        private Guna.UI2.WinForms.Guna2Panel cardKhach;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKhach;
        private System.Windows.Forms.Label capKhach;
        private Guna.UI2.WinForms.Guna2Panel cardHoaDon;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHoaDon;
        private System.Windows.Forms.Label capHoaDon;
        private Guna.UI2.WinForms.Guna2Panel cardDoanhThu;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDoanhThu;
        private System.Windows.Forms.Label capDoanhThu;

        // Main layout
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuNam;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTopSach;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHeatmap;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnApplyRange = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.chkUseRange = new System.Windows.Forms.CheckBox();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            this.numTop = new System.Windows.Forms.NumericUpDown();
            this.lblTopN = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblChao = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowSummary = new System.Windows.Forms.FlowLayoutPanel();
            this.cardSach = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSach = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.capSach = new System.Windows.Forms.Label();
            this.cardKhach = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKhach = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.capKhach = new System.Windows.Forms.Label();
            this.cardHoaDon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHoaDon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.capHoaDon = new System.Windows.Forms.Label();
            this.cardDoanhThu = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDoanhThu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.capDoanhThu = new System.Windows.Forms.Label();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDoanhThuNam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTopSach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvHeatmap = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
            this.flowSummary.SuspendLayout();
            this.cardSach.SuspendLayout();
            this.cardKhach.SuspendLayout();
            this.cardHoaDon.SuspendLayout();
            this.cardDoanhThu.SuspendLayout();
            this.tableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeatmap)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnApplyRange);
            this.panelTop.Controls.Add(this.dtTo);
            this.panelTop.Controls.Add(this.lblTo);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Controls.Add(this.lblFrom);
            this.panelTop.Controls.Add(this.chkUseRange);
            this.panelTop.Controls.Add(this.btnRefreshAll);
            this.panelTop.Controls.Add(this.numTop);
            this.panelTop.Controls.Add(this.lblTopN);
            this.panelTop.Controls.Add(this.cbYear);
            this.panelTop.Controls.Add(this.lblYear);
            this.panelTop.Controls.Add(this.lblChao);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.panelTop.Size = new System.Drawing.Size(1201, 48);
            this.panelTop.TabIndex = 0;
            // 
            // btnApplyRange
            // 
            this.btnApplyRange.Location = new System.Drawing.Point(720, 10);
            this.btnApplyRange.Name = "btnApplyRange";
            this.btnApplyRange.Size = new System.Drawing.Size(72, 24);
            this.btnApplyRange.TabIndex = 11;
            this.btnApplyRange.Text = "Áp dụng";
            this.btnApplyRange.UseVisualStyleBackColor = true;
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(614, 12);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(100, 20);
            this.dtTo.TabIndex = 10;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(554, 16);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(56, 13);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "Đến ngày:";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(447, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(100, 20);
            this.dtFrom.TabIndex = 8;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(393, 16);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(49, 13);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // chkUseRange
            // 
            this.chkUseRange.AutoSize = true;
            this.chkUseRange.Location = new System.Drawing.Point(268, 14);
            this.chkUseRange.Name = "chkUseRange";
            this.chkUseRange.Size = new System.Drawing.Size(133, 17);
            this.chkUseRange.TabIndex = 6;
            this.chkUseRange.Text = "Lọc theo khoảng ngày";
            this.chkUseRange.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshAll.Location = new System.Drawing.Point(1109, 10);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.Size = new System.Drawing.Size(80, 24);
            this.btnRefreshAll.TabIndex = 5;
            this.btnRefreshAll.Text = "Làm mới";
            this.btnRefreshAll.UseVisualStyleBackColor = true;
            // 
            // numTop
            // 
            this.numTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTop.Location = new System.Drawing.Point(1003, 12);
            this.numTop.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTop.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numTop.Name = "numTop";
            this.numTop.Size = new System.Drawing.Size(80, 20);
            this.numTop.TabIndex = 4;
            this.numTop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblTopN
            // 
            this.lblTopN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopN.AutoSize = true;
            this.lblTopN.Location = new System.Drawing.Point(949, 16);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(40, 13);
            this.lblTopN.TabIndex = 3;
            this.lblTopN.Text = "Top N:";
            // 
            // cbYear
            // 
            this.cbYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(845, 12);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(90, 21);
            this.cbYear.TabIndex = 2;
            // 
            // lblYear
            // 
            this.lblYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(806, 16);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Năm:";
            // 
            // lblChao
            // 
            this.lblChao.BackColor = System.Drawing.Color.Transparent;
            this.lblChao.Location = new System.Drawing.Point(8, 14);
            this.lblChao.Name = "lblChao";
            this.lblChao.Size = new System.Drawing.Size(28, 15);
            this.lblChao.TabIndex = 0;
            this.lblChao.Text = "Chào";
            // 
            // flowSummary
            // 
            this.flowSummary.Controls.Add(this.cardSach);
            this.flowSummary.Controls.Add(this.cardKhach);
            this.flowSummary.Controls.Add(this.cardHoaDon);
            this.flowSummary.Controls.Add(this.cardDoanhThu);
            this.flowSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowSummary.Location = new System.Drawing.Point(0, 48);
            this.flowSummary.Name = "flowSummary";
            this.flowSummary.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.flowSummary.Size = new System.Drawing.Size(1201, 92);
            this.flowSummary.TabIndex = 1;
            this.flowSummary.WrapContents = false;
            // 
            // cardSach
            // 
            this.cardSach.BorderRadius = 6;
            this.cardSach.Controls.Add(this.lblSach);
            this.cardSach.Controls.Add(this.capSach);
            this.cardSach.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cardSach.Location = new System.Drawing.Point(0, 0);
            this.cardSach.Margin = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.cardSach.Name = "cardSach";
            this.cardSach.Size = new System.Drawing.Size(260, 76);
            this.cardSach.TabIndex = 0;
            this.cardSach.Paint += new System.Windows.Forms.PaintEventHandler(this.cardSach_Paint);
            // 
            // lblSach
            // 
            this.lblSach.BackColor = System.Drawing.Color.Transparent;
            this.lblSach.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSach.Location = new System.Drawing.Point(12, 36);
            this.lblSach.Name = "lblSach";
            this.lblSach.Size = new System.Drawing.Size(14, 27);
            this.lblSach.TabIndex = 0;
            this.lblSach.Text = "0";
            // 
            // capSach
            // 
            this.capSach.AutoSize = true;
            this.capSach.Location = new System.Drawing.Point(14, 12);
            this.capSach.Name = "capSach";
            this.capSach.Size = new System.Drawing.Size(60, 13);
            this.capSach.TabIndex = 1;
            this.capSach.Text = "Tổng Sách";
            // 
            // cardKhach
            // 
            this.cardKhach.BorderRadius = 6;
            this.cardKhach.Controls.Add(this.lblKhach);
            this.cardKhach.Controls.Add(this.capKhach);
            this.cardKhach.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cardKhach.Location = new System.Drawing.Point(0, 0);
            this.cardKhach.Margin = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.cardKhach.Name = "cardKhach";
            this.cardKhach.Size = new System.Drawing.Size(260, 76);
            this.cardKhach.TabIndex = 1;
            // 
            // lblKhach
            // 
            this.lblKhach.BackColor = System.Drawing.Color.Transparent;
            this.lblKhach.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblKhach.Location = new System.Drawing.Point(12, 36);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new System.Drawing.Size(14, 27);
            this.lblKhach.TabIndex = 0;
            this.lblKhach.Text = "0";
            // 
            // capKhach
            // 
            this.capKhach.AutoSize = true;
            this.capKhach.Location = new System.Drawing.Point(14, 12);
            this.capKhach.Name = "capKhach";
            this.capKhach.Size = new System.Drawing.Size(66, 13);
            this.capKhach.TabIndex = 1;
            this.capKhach.Text = "Tổng Khách";
            // 
            // cardHoaDon
            // 
            this.cardHoaDon.BorderRadius = 6;
            this.cardHoaDon.Controls.Add(this.lblHoaDon);
            this.cardHoaDon.Controls.Add(this.capHoaDon);
            this.cardHoaDon.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cardHoaDon.Location = new System.Drawing.Point(0, 0);
            this.cardHoaDon.Margin = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.cardHoaDon.Name = "cardHoaDon";
            this.cardHoaDon.Size = new System.Drawing.Size(260, 76);
            this.cardHoaDon.TabIndex = 2;
            // 
            // lblHoaDon
            // 
            this.lblHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.lblHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHoaDon.Location = new System.Drawing.Point(12, 36);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.Size = new System.Drawing.Size(14, 27);
            this.lblHoaDon.TabIndex = 0;
            this.lblHoaDon.Text = "0";
            // 
            // capHoaDon
            // 
            this.capHoaDon.AutoSize = true;
            this.capHoaDon.Location = new System.Drawing.Point(14, 12);
            this.capHoaDon.Name = "capHoaDon";
            this.capHoaDon.Size = new System.Drawing.Size(77, 13);
            this.capHoaDon.TabIndex = 1;
            this.capHoaDon.Text = "Tổng Hóa đơn";
            // 
            // cardDoanhThu
            // 
            this.cardDoanhThu.BorderRadius = 6;
            this.cardDoanhThu.Controls.Add(this.lblDoanhThu);
            this.cardDoanhThu.Controls.Add(this.capDoanhThu);
            this.cardDoanhThu.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cardDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.cardDoanhThu.Margin = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.cardDoanhThu.Name = "cardDoanhThu";
            this.cardDoanhThu.Size = new System.Drawing.Size(260, 76);
            this.cardDoanhThu.TabIndex = 3;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.Location = new System.Drawing.Point(12, 36);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(14, 27);
            this.lblDoanhThu.TabIndex = 0;
            this.lblDoanhThu.Text = "0";
            // 
            // capDoanhThu
            // 
            this.capDoanhThu.AutoSize = true;
            this.capDoanhThu.Location = new System.Drawing.Point(14, 12);
            this.capDoanhThu.Name = "capDoanhThu";
            this.capDoanhThu.Size = new System.Drawing.Size(85, 13);
            this.capDoanhThu.TabIndex = 1;
            this.capDoanhThu.Text = "Tổng Doanh thu";
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMain.Controls.Add(this.chartDoanhThu, 0, 0);
            this.tableMain.Controls.Add(this.chartDoanhThuNam, 0, 1);
            this.tableMain.Controls.Add(this.dgvTopSach, 1, 0);
            this.tableMain.Controls.Add(this.dgvHeatmap, 1, 1);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 140);
            this.tableMain.Name = "tableMain";
            this.tableMain.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
            this.tableMain.RowCount = 2;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMain.Size = new System.Drawing.Size(1201, 487);
            this.tableMain.TabIndex = 2;
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Location = new System.Drawing.Point(11, 7);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(585, 233);
            this.chartDoanhThu.TabIndex = 0;
            // 
            // chartDoanhThuNam
            // 
            this.chartDoanhThuNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThuNam.Location = new System.Drawing.Point(11, 246);
            this.chartDoanhThuNam.Name = "chartDoanhThuNam";
            this.chartDoanhThuNam.Size = new System.Drawing.Size(585, 233);
            this.chartDoanhThuNam.TabIndex = 1;
            // 
            // dgvTopSach
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTopSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTopSach.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTopSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopSach.Location = new System.Drawing.Point(602, 7);
            this.dgvTopSach.Name = "dgvTopSach";
            this.dgvTopSach.RowHeadersVisible = false;
            this.dgvTopSach.Size = new System.Drawing.Size(588, 233);
            this.dgvTopSach.TabIndex = 2;
            this.dgvTopSach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopSach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTopSach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTopSach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTopSach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTopSach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopSach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopSach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTopSach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopSach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTopSach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTopSach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTopSach.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvTopSach.ThemeStyle.ReadOnly = false;
            this.dgvTopSach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopSach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopSach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTopSach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTopSach.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTopSach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopSach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvHeatmap
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvHeatmap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeatmap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHeatmap.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHeatmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeatmap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHeatmap.Location = new System.Drawing.Point(602, 246);
            this.dgvHeatmap.Name = "dgvHeatmap";
            this.dgvHeatmap.RowHeadersVisible = false;
            this.dgvHeatmap.Size = new System.Drawing.Size(588, 233);
            this.dgvHeatmap.TabIndex = 3;
            this.dgvHeatmap.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHeatmap.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHeatmap.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHeatmap.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHeatmap.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHeatmap.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHeatmap.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHeatmap.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHeatmap.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHeatmap.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHeatmap.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHeatmap.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHeatmap.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvHeatmap.ThemeStyle.ReadOnly = false;
            this.dgvHeatmap.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHeatmap.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHeatmap.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHeatmap.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHeatmap.ThemeStyle.RowsStyle.Height = 22;
            this.dgvHeatmap.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHeatmap.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableMain);
            this.Controls.Add(this.flowSummary);
            this.Controls.Add(this.panelTop);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1201, 627);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
            this.flowSummary.ResumeLayout(false);
            this.cardSach.ResumeLayout(false);
            this.cardSach.PerformLayout();
            this.cardKhach.ResumeLayout(false);
            this.cardKhach.PerformLayout();
            this.cardHoaDon.ResumeLayout(false);
            this.cardHoaDon.PerformLayout();
            this.cardDoanhThu.ResumeLayout(false);
            this.cardDoanhThu.PerformLayout();
            this.tableMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeatmap)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
