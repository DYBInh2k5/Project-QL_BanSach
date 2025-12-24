namespace QLBanSach_GUI.UserControls
{
    partial class UC_KhuyenMai
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
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.cbHinhThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.txtCoupon = new System.Windows.Forms.TextBox();
            this.dtBD = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgvKM = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.dtKT = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(127, 123);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(100, 20);
            this.txtTenKM.TabIndex = 0;
            // 
            // cbHinhThuc
            // 
            this.cbHinhThuc.BackColor = System.Drawing.Color.Transparent;
            this.cbHinhThuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHinhThuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbHinhThuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbHinhThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbHinhThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbHinhThuc.ItemHeight = 30;
            this.cbHinhThuc.Items.AddRange(new object[] {
            "%",
            "TANG1",
            "COUPON"});
            this.cbHinhThuc.Location = new System.Drawing.Point(342, 91);
            this.cbHinhThuc.Name = "cbHinhThuc";
            this.cbHinhThuc.Size = new System.Drawing.Size(140, 36);
            this.cbHinhThuc.TabIndex = 1;
            this.cbHinhThuc.SelectedIndexChanged += new System.EventHandler(this.cbHinhThuc_SelectedIndexChanged);
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(127, 177);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(100, 20);
            this.txtGiaTri.TabIndex = 2;
            // 
            // txtCoupon
            // 
            this.txtCoupon.Location = new System.Drawing.Point(127, 233);
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.Size = new System.Drawing.Size(100, 20);
            this.txtCoupon.TabIndex = 3;
            // 
            // dtBD
            // 
            this.dtBD.Checked = true;
            this.dtBD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtBD.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtBD.Location = new System.Drawing.Point(364, 19);
            this.dtBD.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtBD.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtBD.Name = "dtBD";
            this.dtBD.Size = new System.Drawing.Size(200, 36);
            this.dtBD.TabIndex = 4;
            this.dtBD.Value = new System.DateTime(2025, 11, 28, 11, 53, 55, 396);
            // 
            // dgvKM
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvKM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKM.ColumnHeadersHeight = 36;
            this.dgvKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKM.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKM.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKM.Location = new System.Drawing.Point(81, 292);
            this.dgvKM.Name = "dgvKM";
            this.dgvKM.RowHeadersVisible = false;
            this.dgvKM.Size = new System.Drawing.Size(401, 279);
            this.dgvKM.TabIndex = 5;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKM.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKM.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKM.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvKM.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKM.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKM.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKM.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvKM.ThemeStyle.ReadOnly = false;
            this.dgvKM.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKM.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKM.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKM.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKM.ThemeStyle.RowsStyle.Height = 22;
            this.dgvKM.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKM.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            //this.dgvKM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKM_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(601, 292);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(180, 45);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            // 
            // btnSua
            // 
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(601, 412);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(180, 45);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            // 
            // btnXoa
            // 
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(601, 496);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(180, 45);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            // 
            // dtKT
            // 
            this.dtKT.Checked = true;
            this.dtKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtKT.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtKT.Location = new System.Drawing.Point(601, 19);
            this.dtKT.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtKT.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtKT.Name = "dtKT";
            this.dtKT.Size = new System.Drawing.Size(200, 36);
            this.dtKT.TabIndex = 9;
            this.dtKT.Value = new System.DateTime(2025, 11, 28, 11, 53, 55, 396);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(42, 182);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(31, 15);
            this.guna2HtmlLabel2.TabIndex = 11;
            this.guna2HtmlLabel2.Text = "GiaTri";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(42, 238);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(40, 15);
            this.guna2HtmlLabel3.TabIndex = 12;
            this.guna2HtmlLabel3.Text = "Coupon";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(42, 128);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(38, 15);
            this.guna2HtmlLabel1.TabIndex = 13;
            this.guna2HtmlLabel1.Text = "TênKM";
            // 
            // UC_KhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.dtKT);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvKM);
            this.Controls.Add(this.dtBD);
            this.Controls.Add(this.txtCoupon);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.cbHinhThuc);
            this.Controls.Add(this.txtTenKM);
            this.Name = "UC_KhuyenMai";
            this.Size = new System.Drawing.Size(827, 589);
            this.Load += new System.EventHandler(this.UC_KhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenKM;
        private Guna.UI2.WinForms.Guna2ComboBox cbHinhThuc;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.TextBox txtCoupon;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtBD;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKM;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtKT;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
