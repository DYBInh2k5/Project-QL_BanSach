namespace QLBanSach_GUI.UserControls
{
    partial class UC_Sach
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvSach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtTenSach = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSoLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDonGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTheLoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTacGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnImportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.progressBarImport = new System.Windows.Forms.ProgressBar();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.pnlProgressContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.pnlProgressContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(16, 3);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tìm tên/ thể loại...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(229, 36);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvSach
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSach.ColumnHeadersHeight = 4;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSach.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSach.Location = new System.Drawing.Point(16, 66);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersVisible = false;
            this.dgvSach.Size = new System.Drawing.Size(900, 259);
            this.dgvSach.TabIndex = 1;
            this.dgvSach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSach.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvSach.ThemeStyle.ReadOnly = false;
            this.dgvSach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSach.ThemeStyle.RowsStyle.Height = 22;
            this.dgvSach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            // 
            // txtTenSach
            // 
            this.txtTenSach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenSach.DefaultText = "";
            this.txtTenSach.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenSach.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenSach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenSach.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenSach.Location = new System.Drawing.Point(16, 346);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.PlaceholderText = "Tên Sách";
            this.txtTenSach.SelectedText = "";
            this.txtTenSach.Size = new System.Drawing.Size(163, 36);
            this.txtTenSach.TabIndex = 2;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoLuong.DefaultText = "";
            this.txtSoLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSoLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSoLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoLuong.Location = new System.Drawing.Point(185, 346);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.PlaceholderText = "Số Lượng";
            this.txtSoLuong.SelectedText = "";
            this.txtSoLuong.Size = new System.Drawing.Size(77, 36);
            this.txtSoLuong.TabIndex = 3;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDonGia.DefaultText = "";
            this.txtDonGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDonGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDonGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDonGia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDonGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDonGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDonGia.Location = new System.Drawing.Point(185, 388);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.PlaceholderText = "Đơn Giá";
            this.txtDonGia.SelectedText = "";
            this.txtDonGia.Size = new System.Drawing.Size(77, 36);
            this.txtDonGia.TabIndex = 4;
            // 
            // txtTheLoai
            // 
            this.txtTheLoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTheLoai.DefaultText = "";
            this.txtTheLoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTheLoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTheLoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTheLoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTheLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTheLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTheLoai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTheLoai.Location = new System.Drawing.Point(16, 388);
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.PlaceholderText = "Thể Loại";
            this.txtTheLoai.SelectedText = "";
            this.txtTheLoai.Size = new System.Drawing.Size(163, 36);
            this.txtTheLoai.TabIndex = 5;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTacGia.DefaultText = "";
            this.txtTacGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTacGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTacGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTacGia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTacGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTacGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTacGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTacGia.Location = new System.Drawing.Point(16, 430);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.PlaceholderText = "Tác Giả";
            this.txtTacGia.SelectedText = "";
            this.txtTacGia.Size = new System.Drawing.Size(163, 36);
            this.txtTacGia.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(16, 501);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(180, 45);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(225, 552);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(180, 45);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(16, 552);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(180, 45);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(225, 501);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(180, 45);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(264, 3);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 11;
            this.guna2Button1.Text = "Thể loại";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(430, 501);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(180, 45);
            this.btnExportExcel.TabIndex = 12;
            this.btnExportExcel.Text = "Xuất sách";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Location = new System.Drawing.Point(430, 552);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(180, 45);
            this.btnImportExcel.TabIndex = 13;
            this.btnImportExcel.Text = "Nhập sách";
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // progressBarImport
            // 
            this.progressBarImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarImport.Location = new System.Drawing.Point(0, 20);
            this.progressBarImport.Name = "progressBarImport";
            this.progressBarImport.Size = new System.Drawing.Size(595, 23);
            this.progressBarImport.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarImport.TabIndex = 14;
            this.progressBarImport.Visible = false;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProgressStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgressStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.lblProgressStatus.Location = new System.Drawing.Point(0, 0);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(595, 20);
            this.lblProgressStatus.TabIndex = 15;
            this.lblProgressStatus.Text = "Đang xử lý...";
            this.lblProgressStatus.Visible = false;
            // 
            // pnlProgressContainer
            // 
            this.pnlProgressContainer.Controls.Add(this.progressBarImport);
            this.pnlProgressContainer.Controls.Add(this.lblProgressStatus);
            this.pnlProgressContainer.Location = new System.Drawing.Point(620, 501);
            this.pnlProgressContainer.Name = "pnlProgressContainer";
            this.pnlProgressContainer.Size = new System.Drawing.Size(595, 96);
            this.pnlProgressContainer.TabIndex = 16;
            this.pnlProgressContainer.Visible = false;
            // 
            // UC_Sach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlProgressContainer);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTacGia);
            this.Controls.Add(this.txtTheLoai);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.dgvSach);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "UC_Sach";
            this.Size = new System.Drawing.Size(1201, 627);
            this.Load += new System.EventHandler(this.UC_Sach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.pnlProgressContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSach;
        private Guna.UI2.WinForms.Guna2TextBox txtTenSach;
        private Guna.UI2.WinForms.Guna2TextBox txtSoLuong;
        private Guna.UI2.WinForms.Guna2TextBox txtDonGia;
        private Guna.UI2.WinForms.Guna2TextBox txtTheLoai;
        private Guna.UI2.WinForms.Guna2TextBox txtTacGia;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2Button btnImportExcel;
        private System.Windows.Forms.ProgressBar progressBarImport;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.Panel pnlProgressContainer;
    }
}
