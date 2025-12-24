namespace QLBanSach_GUI
{
    partial class frmQuanLyTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyTaiKhoan));
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.tvRoleGroup = new System.Windows.Forms.TreeView();
            this.panelCenter = new Guna.UI2.WinForms.Guna2Panel();
            this.splitCenter = new System.Windows.Forms.SplitContainer();
            this.dgvTaiKhoan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lvAvatar = new System.Windows.Forms.ListView();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitleDetail = new System.Windows.Forms.Label();
            this.btnDoiAnh = new Guna.UI2.WinForms.Guna2Button();
            this.txtMaNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSdt = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCCCD = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbVaiTro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtNgayTao = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.avatarBorderPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.picAvatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.panelLeft.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCenter)).BeginInit();
            this.splitCenter.Panel1.SuspendLayout();
            this.splitCenter.Panel2.SuspendLayout();
            this.splitCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.panelRight.SuspendLayout();
            this.avatarBorderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BorderRadius = 8;
            this.panelLeft.BorderThickness = 1;
            this.panelLeft.BorderColor = System.Drawing.Color.Silver;
            this.panelLeft.Controls.Add(this.tvRoleGroup);
            this.panelLeft.Controls.Add(this.txtTimKiem);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.FillColor = System.Drawing.Color.White;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(320, 700);
            this.panelLeft.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 6;
            this.txtTimKiem.PlaceholderText = "Tìm kiếm theo tên, tài khoản, CCCD...";
            this.txtTimKiem.IconLeft = ((System.Drawing.Image)(resources.GetObject("searchIcon")));
            this.txtTimKiem.Location = new System.Drawing.Point(16, 16);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(288, 36);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // tvRoleGroup
            // 
            this.tvRoleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRoleGroup.FullRowSelect = true;
            this.tvRoleGroup.HideSelection = false;
            this.tvRoleGroup.Location = new System.Drawing.Point(16, 68);
            this.tvRoleGroup.Name = "tvRoleGroup";
            this.tvRoleGroup.Size = new System.Drawing.Size(288, 616);
            this.tvRoleGroup.TabIndex = 2;
            // 
            // panelCenter
            // 
            this.panelCenter.BorderRadius = 8;
            this.panelCenter.BorderThickness = 1;
            this.panelCenter.BorderColor = System.Drawing.Color.Silver;
            this.panelCenter.Controls.Add(this.splitCenter);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.FillColor = System.Drawing.Color.White;
            this.panelCenter.Location = new System.Drawing.Point(320, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(640, 700);
            this.panelCenter.TabIndex = 1;
            // 
            // splitCenter
            // 
            this.splitCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCenter.Location = new System.Drawing.Point(0, 0);
            this.splitCenter.Name = "splitCenter";
            this.splitCenter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCenter.Panel1
            // 
            this.splitCenter.Panel1.Controls.Add(this.dgvTaiKhoan);
            // 
            // splitCenter.Panel2
            // 
            this.splitCenter.Panel2.Controls.Add(this.lvAvatar);
            this.splitCenter.Size = new System.Drawing.Size(640, 700);
            this.splitCenter.SplitterDistance = 380;
            this.splitCenter.TabIndex = 0;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.AllowUserToResizeRows = false;
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaiKhoan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTaiKhoan.ColumnHeadersHeight = 28;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.EnableHeadersVisualStyles = false;
            this.dgvTaiKhoan.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.dgvTaiKhoan.MultiSelect = false;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowTemplate.Height = 28;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.TabIndex = 0;
            this.dgvTaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellClick);
            this.dgvTaiKhoan.SelectionChanged += new System.EventHandler(this.dgvTaiKhoan_SelectionChanged);
            this.dgvTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellContentClick);
            // 
            // lvAvatar
            // 
            this.lvAvatar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAvatar.HideSelection = false;
            this.lvAvatar.MultiSelect = false;
            this.lvAvatar.UseCompatibleStateImageBehavior = false;
            this.lvAvatar.View = System.Windows.Forms.View.LargeIcon;
            this.lvAvatar.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.BorderRadius = 8;
            this.panelRight.BorderThickness = 1;
            this.panelRight.BorderColor = System.Drawing.Color.Silver;
            this.panelRight.Controls.Add(this.chkTrangThai);
            this.panelRight.Controls.Add(this.lblTitleDetail);
            this.panelRight.Controls.Add(this.btnDoiAnh);
            this.panelRight.Controls.Add(this.txtMaNV);
            this.panelRight.Controls.Add(this.txtHoTen);
            this.panelRight.Controls.Add(this.txtSdt);
            this.panelRight.Controls.Add(this.txtEmail);
            this.panelRight.Controls.Add(this.txtCCCD);
            this.panelRight.Controls.Add(this.txtTaiKhoan);
            this.panelRight.Controls.Add(this.txtMatKhau);
            this.panelRight.Controls.Add(this.cbVaiTro);
            this.panelRight.Controls.Add(this.dtNgaySinh);
            this.panelRight.Controls.Add(this.dtNgayTao);
            this.panelRight.Controls.Add(this.btnThem);
            this.panelRight.Controls.Add(this.btnSua);
            this.panelRight.Controls.Add(this.btnXoa);
            this.panelRight.Controls.Add(this.btnLamMoi);
            this.panelRight.Controls.Add(this.btnRegister);
            this.panelRight.Controls.Add(this.avatarBorderPanel);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.FillColor = System.Drawing.Color.White;
            this.panelRight.Location = new System.Drawing.Point(960, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(340, 700);
            this.panelRight.TabIndex = 2;
            this.panelRight.AutoScroll = true;
            // 
            // lblTitleDetail
            // 
            this.lblTitleDetail.AutoSize = true;
            this.lblTitleDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleDetail.Location = new System.Drawing.Point(16, 16);
            this.lblTitleDetail.Name = "lblTitleDetail";
            this.lblTitleDetail.Size = new System.Drawing.Size(157, 20);
            this.lblTitleDetail.TabIndex = 0;
            this.lblTitleDetail.Text = "Thông tin chi tiết NV";
            // 
            // btnDoiAnh
            // 
            this.btnDoiAnh.BorderRadius = 6;
            this.btnDoiAnh.Location = new System.Drawing.Point(20, 172);
            this.btnDoiAnh.Name = "btnDoiAnh";
            this.btnDoiAnh.Size = new System.Drawing.Size(120, 30);
            this.btnDoiAnh.TabIndex = 2;
            this.btnDoiAnh.Text = "Đổi ảnh...";
            this.btnDoiAnh.Click += new System.EventHandler(this.btnDoiAnh_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNV.BorderRadius = 6;
            this.txtMaNV.PlaceholderText = "Mã nhân viên";
            this.txtMaNV.Location = new System.Drawing.Point(160, 48);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(160, 32);
            this.txtMaNV.TabIndex = 3;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoTen.BorderRadius = 6;
            this.txtHoTen.PlaceholderText = "Họ tên";
            this.txtHoTen.Location = new System.Drawing.Point(160, 88);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(160, 32);
            this.txtHoTen.TabIndex = 4;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // txtSdt
            // 
            this.txtSdt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSdt.BorderRadius = 6;
            this.txtSdt.PlaceholderText = "Điện thoại";
            this.txtSdt.Location = new System.Drawing.Point(160, 128);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(160, 32);
            this.txtSdt.TabIndex = 5;
            this.txtSdt.TextChanged += new System.EventHandler(this.txtSdt_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Location = new System.Drawing.Point(20, 220);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 32);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtCCCD
            // 
            this.txtCCCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCCCD.BorderRadius = 6;
            this.txtCCCD.PlaceholderText = "CCCD";
            this.txtCCCD.Location = new System.Drawing.Point(20, 260);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(300, 32);
            this.txtCCCD.TabIndex = 7;
            this.txtCCCD.TextChanged += new System.EventHandler(this.txtCCCD_TextChanged);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaiKhoan.BorderRadius = 6;
            this.txtTaiKhoan.PlaceholderText = "Tài khoản";
            this.txtTaiKhoan.Location = new System.Drawing.Point(20, 300);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(300, 32);
            this.txtTaiKhoan.TabIndex = 8;
            this.txtTaiKhoan.TextChanged += new System.EventHandler(this.txtTaiKhoan_TextChanged);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhau.BorderRadius = 6;
            this.txtMatKhau.PlaceholderText = "Mật khẩu";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Location = new System.Drawing.Point(20, 340);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(300, 32);
            this.txtMatKhau.TabIndex = 9;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // cbVaiTro
            // 
            this.cbVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVaiTro.BorderRadius = 6;
            this.cbVaiTro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVaiTro.ItemHeight = 30;
            this.cbVaiTro.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên bán hàng"});
            this.cbVaiTro.Location = new System.Drawing.Point(20, 380);
            this.cbVaiTro.Name = "cbVaiTro";
            this.cbVaiTro.Size = new System.Drawing.Size(300, 36);
            this.cbVaiTro.TabIndex = 10;
            this.cbVaiTro.SelectedIndexChanged += new System.EventHandler(this.cbVaiTro_SelectedIndexChanged);
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgaySinh.BorderRadius = 6;
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Location = new System.Drawing.Point(20, 426);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(300, 32);
            this.dtNgaySinh.TabIndex = 11;
            // 
            // dtNgayTao
            // 
            this.dtNgayTao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgayTao.BorderRadius = 6;
            this.dtNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayTao.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTao.Location = new System.Drawing.Point(20, 466);
            this.dtNgayTao.Name = "dtNgayTao";
            this.dtNgayTao.Size = new System.Drawing.Size(300, 32);
            this.dtNgayTao.TabIndex = 12;
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 6;
            this.btnThem.Location = new System.Drawing.Point(20, 512);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 36);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 6;
            this.btnSua.Location = new System.Drawing.Point(116, 512);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 36);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 6;
            this.btnXoa.Location = new System.Drawing.Point(212, 512);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 36);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 6;
            this.btnLamMoi.Location = new System.Drawing.Point(20, 556);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(160, 36);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "Mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BorderRadius = 6;
            this.btnRegister.Location = new System.Drawing.Point(192, 556);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(128, 36);
            this.btnRegister.TabIndex = 17;
            this.btnRegister.Text = "Đăng ký tài khoản";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // avatarBorderPanel
            // 
            this.avatarBorderPanel.BorderColor = System.Drawing.Color.Silver;
            this.avatarBorderPanel.BorderThickness = 1;
            this.avatarBorderPanel.BorderRadius = 8;
            this.avatarBorderPanel.Location = new System.Drawing.Point(16, 44);
            this.avatarBorderPanel.Name = "avatarBorderPanel";
            this.avatarBorderPanel.Size = new System.Drawing.Size(128, 128);
            // 
            // picAvatar
            // 
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(4, 4);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(120, 120);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            this.avatarBorderPanel.Controls.Add(this.picAvatar);
            // 
            // imageList1
            // 
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Location = new System.Drawing.Point(20, 610);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(140, 17);
            this.chkTrangThai.TabIndex = 18;
            this.chkTrangThai.Text = "Hoạt động (Trạng thái)";
            this.chkTrangThai.Checked = true;
            // 
            // frmQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "frmQuanLyTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản nhân viên";
            this.Load += new System.EventHandler(this.frmQuanLyTaiKhoan_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.splitCenter.Panel1.ResumeLayout(false);
            this.splitCenter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCenter)).EndInit();
            this.splitCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.avatarBorderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private System.Windows.Forms.TreeView tvRoleGroup;
        private Guna.UI2.WinForms.Guna2Panel panelCenter;
        private System.Windows.Forms.SplitContainer splitCenter;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTaiKhoan;
        private System.Windows.Forms.ListView lvAvatar;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2Panel panelRight;
        private System.Windows.Forms.Label lblTitleDetail;
        private Guna.UI2.WinForms.Guna2Button btnDoiAnh;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNV;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTen;
        private Guna.UI2.WinForms.Guna2TextBox txtSdt;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtCCCD;
        private Guna.UI2.WinForms.Guna2TextBox txtTaiKhoan;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private Guna.UI2.WinForms.Guna2ComboBox cbVaiTro;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNgaySinh;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNgayTao;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2Panel avatarBorderPanel;
        private Guna.UI2.WinForms.Guna2PictureBox picAvatar;
        private System.Windows.Forms.CheckBox chkTrangThai;
    }
}