namespace QLBanSach_GUI.UserControls
{
    partial class UC_POS
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
            this.flpBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.lvCart = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtGiamGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtVAT = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtThanhToan = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.BtnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.cbKhuyenMai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtCoupon = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnKiemTra = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // flpBooks
            // 
            this.flpBooks.AutoScroll = true;
            this.flpBooks.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpBooks.Location = new System.Drawing.Point(0, 0);
            this.flpBooks.Name = "flpBooks";
            this.flpBooks.Size = new System.Drawing.Size(200, 536);
            this.flpBooks.TabIndex = 0;
            this.flpBooks.Paint += new System.Windows.Forms.PaintEventHandler(this.flpBooks_Paint);
            // 
            // lvCart
            // 
            this.lvCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvCart.FullRowSelect = true;
            this.lvCart.GridLines = true;
            this.lvCart.HideSelection = false;
            this.lvCart.Location = new System.Drawing.Point(563, 21);
            this.lvCart.Name = "lvCart";
            this.lvCart.Size = new System.Drawing.Size(253, 263);
            this.lvCart.TabIndex = 1;
            this.lvCart.UseCompatibleStateImageBehavior = false;
            this.lvCart.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên sách";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn Giá";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongTien.DefaultText = "";
            this.txtTongTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTongTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTongTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTongTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongTien.Location = new System.Drawing.Point(216, 21);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.PlaceholderText = "Tổng tiền";
            this.txtTongTien.SelectedText = "";
            this.txtTongTien.Size = new System.Drawing.Size(200, 36);
            this.txtTongTien.TabIndex = 2;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGiamGia.DefaultText = "";
            this.txtGiamGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGiamGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGiamGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGiamGia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGiamGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGiamGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiamGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGiamGia.Location = new System.Drawing.Point(216, 84);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.PlaceholderText = "Giảm giá";
            this.txtGiamGia.SelectedText = "";
            this.txtGiamGia.Size = new System.Drawing.Size(200, 36);
            this.txtGiamGia.TabIndex = 3;
            // 
            // txtVAT
            // 
            this.txtVAT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVAT.DefaultText = "";
            this.txtVAT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVAT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVAT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVAT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVAT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVAT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVAT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVAT.Location = new System.Drawing.Point(216, 143);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.PlaceholderText = "VAT";
            this.txtVAT.SelectedText = "";
            this.txtVAT.Size = new System.Drawing.Size(200, 36);
            this.txtVAT.TabIndex = 4;
            // 
            // txtThanhToan
            // 
            this.txtThanhToan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThanhToan.DefaultText = "";
            this.txtThanhToan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThanhToan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThanhToan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtThanhToan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThanhToan.Location = new System.Drawing.Point(216, 205);
            this.txtThanhToan.Name = "txtThanhToan";
            this.txtThanhToan.PlaceholderText = "Thanh Toán";
            this.txtThanhToan.SelectedText = "";
            this.txtThanhToan.Size = new System.Drawing.Size(200, 36);
            this.txtThanhToan.TabIndex = 5;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(216, 293);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(180, 45);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(216, 378);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(180, 45);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            // 
            // BtnAdd
            // 
            this.BtnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(216, 463);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(180, 45);
            this.BtnAdd.TabIndex = 8;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // cbKhuyenMai
            // 
            this.cbKhuyenMai.BackColor = System.Drawing.Color.Transparent;
            this.cbKhuyenMai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbKhuyenMai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhuyenMai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbKhuyenMai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbKhuyenMai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbKhuyenMai.ItemHeight = 30;
            this.cbKhuyenMai.Location = new System.Drawing.Point(553, 301);
            this.cbKhuyenMai.Name = "cbKhuyenMai";
            this.cbKhuyenMai.Size = new System.Drawing.Size(140, 36);
            this.cbKhuyenMai.TabIndex = 9;
            this.cbKhuyenMai.SelectedIndexChanged += new System.EventHandler(this.cbKhuyenMai_SelectedIndexChanged);
            // 
            // txtCoupon
            // 
            this.txtCoupon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCoupon.DefaultText = "";
            this.txtCoupon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCoupon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCoupon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCoupon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCoupon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCoupon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCoupon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCoupon.Location = new System.Drawing.Point(553, 389);
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.PlaceholderText = "Copou";
            this.txtCoupon.SelectedText = "";
            this.txtCoupon.Size = new System.Drawing.Size(200, 36);
            this.txtCoupon.TabIndex = 10;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKiemTra.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKiemTra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKiemTra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKiemTra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKiemTra.ForeColor = System.Drawing.Color.White;
            this.btnKiemTra.Location = new System.Drawing.Point(553, 463);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(180, 45);
            this.btnKiemTra.TabIndex = 11;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // UC_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.txtCoupon);
            this.Controls.Add(this.cbKhuyenMai);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.txtThanhToan);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.lvCart);
            this.Controls.Add(this.flpBooks);
            this.Name = "UC_POS";
            this.Size = new System.Drawing.Size(841, 536);
            this.Load += new System.EventHandler(this.UC_POS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBooks;
        private System.Windows.Forms.ListView lvCart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Guna.UI2.WinForms.Guna2TextBox txtTongTien;
        private Guna.UI2.WinForms.Guna2TextBox txtGiamGia;
        private Guna.UI2.WinForms.Guna2TextBox txtVAT;
        private Guna.UI2.WinForms.Guna2TextBox txtThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button BtnAdd;
        private Guna.UI2.WinForms.Guna2ComboBox cbKhuyenMai;
        private Guna.UI2.WinForms.Guna2TextBox txtCoupon;
        private Guna.UI2.WinForms.Guna2Button btnKiemTra;
    }
}
