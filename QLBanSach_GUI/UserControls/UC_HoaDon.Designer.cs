namespace QLBanSach_GUI.UserControls
{
    partial class UC_HoaDon
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
            this.cboSach = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDonGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.numSoLuong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhuyenMai = new Guna.UI2.WinForms.Guna2Button();
            this.lblCustomerInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnChonKhach = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlInput = new Guna.UI2.WinForms.Guna2GroupBox();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSach
            // 
            this.cboSach.BackColor = System.Drawing.Color.Transparent;
            this.cboSach.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSach.ItemHeight = 30;
            this.cboSach.Location = new System.Drawing.Point(17, 39);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(223, 36);
            this.cboSach.TabIndex = 0;
            this.cboSach.SelectedIndexChanged += new System.EventHandler(this.cboSach_SelectedIndexChanged_1);
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
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDonGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDonGia.Location = new System.Drawing.Point(254, 39);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.PlaceholderText = "Đơn giá";
            this.txtDonGia.SelectedText = "";
            this.txtDonGia.Size = new System.Drawing.Size(154, 31);
            this.txtDonGia.TabIndex = 1;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // numSoLuong
            // 
            this.numSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.numSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSoLuong.Location = new System.Drawing.Point(413, 39);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(103, 31);
            this.numSoLuong.TabIndex = 2;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.ValueChanged += new System.EventHandler(this.numSoLuong_ValueChanged);
            // 
            // btnThem
            // 
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(531, 39);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(129, 31);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm vào giỏ";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTiet.ColumnHeadersHeight = 36;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(22, 165);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowTemplate.Height = 28;
            this.dgvChiTiet.Size = new System.Drawing.Size(985, 277);
            this.dgvChiTiet.TabIndex = 4;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvChiTiet.ThemeStyle.ReadOnly = false;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvChiTiet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.Height = 28;
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChiTiet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellContentClick);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTongTien.Location = new System.Drawing.Point(14, 26);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(122, 19);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhToan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(643, 19);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(154, 31);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click_1);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhuyenMai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhuyenMai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhuyenMai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhuyenMai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.White;
            this.btnKhuyenMai.Location = new System.Drawing.Point(497, 19);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(137, 31);
            this.btnKhuyenMai.TabIndex = 7;
            this.btnKhuyenMai.Text = "Discount";
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.lblCustomerInfo.Location = new System.Drawing.Point(669, 46);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(107, 19);
            this.lblCustomerInfo.TabIndex = 8;
            this.lblCustomerInfo.Text = "Khách: Chưa chọn";
            // 
            // btnChonKhach
            // 
            this.btnChonKhach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChonKhach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChonKhach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChonKhach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChonKhach.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnChonKhach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChonKhach.ForeColor = System.Drawing.Color.White;
            this.btnChonKhach.Location = new System.Drawing.Point(823, 39);
            this.btnChonKhach.Name = "btnChonKhach";
            this.btnChonKhach.Size = new System.Drawing.Size(137, 31);
            this.btnChonKhach.TabIndex = 9;
            this.btnChonKhach.Text = "Chọn khách";
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(806, 19);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(154, 31);
            this.guna2Button2.TabIndex = 10;
            this.guna2Button2.Text = "In hóa đơn";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1029, 52);
            this.pnlTop.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hóa đơn bán sách";
            // 
            // pnlInput
            // 
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(234)))), ((int)(((byte)(239)))));
            this.pnlInput.Controls.Add(this.cboSach);
            this.pnlInput.Controls.Add(this.txtDonGia);
            this.pnlInput.Controls.Add(this.numSoLuong);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.lblCustomerInfo);
            this.pnlInput.Controls.Add(this.btnChonKhach);
            this.pnlInput.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(234)))), ((int)(((byte)(239)))));
            this.pnlInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlInput.Location = new System.Drawing.Point(22, 61);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(985, 95);
            this.pnlInput.TabIndex = 12;
            this.pnlInput.Text = "Chọn sản phẩm";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.Controls.Add(this.lblTongTien);
            this.pnlBottom.Controls.Add(this.btnKhuyenMai);
            this.pnlBottom.Controls.Add(this.btnThanhToan);
            this.pnlBottom.Controls.Add(this.guna2Button2);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(22, 451);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(985, 69);
            this.pnlBottom.TabIndex = 13;
            // 
            // UC_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlTop);
            this.Name = "UC_HoaDon";
            this.Size = new System.Drawing.Size(1029, 543);
            this.Load += new System.EventHandler(this.UC_HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboSach;
        private Guna.UI2.WinForms.Guna2TextBox txtDonGia;
        private Guna.UI2.WinForms.Guna2NumericUpDown numSoLuong;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblTongTien;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnKhuyenMai;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCustomerInfo;
        private Guna.UI2.WinForms.Guna2Button btnChonKhach;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2GroupBox pnlInput;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
    }
}
