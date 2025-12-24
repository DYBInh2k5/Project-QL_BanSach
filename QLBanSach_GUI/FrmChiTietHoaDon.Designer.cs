namespace QLBanSach_GUI
{
    partial class FrmChiTietHoaDon
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle defaultStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMaHD = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTongTien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblKhuyenMai = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1072, 80);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblMaHD);
            this.pnlHeader.Controls.Add(this.lblNgay);
            this.pnlHeader.Controls.Add(this.lblTongTien);
            this.pnlHeader.Controls.Add(this.lblKhuyenMai);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblTitle.Location = new System.Drawing.Point(24, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(188, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết hóa đơn";
            // 
            // lblMaHD
            // 
            this.lblMaHD.BackColor = System.Drawing.Color.Transparent;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.lblMaHD.Location = new System.Drawing.Point(24, 50);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(75, 19);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.Text = "Mã hóa đơn:";
            // 
            // lblNgay
            // 
            this.lblNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.lblNgay.Location = new System.Drawing.Point(360, 50);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(63, 19);
            this.lblNgay.TabIndex = 2;
            this.lblNgay.Text = "Ngày lập:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTongTien.Location = new System.Drawing.Point(720, 50);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(71, 19);
            this.lblTongTien.TabIndex = 3;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // lblKhuyenMai
            // 
            this.lblKhuyenMai.BackColor = System.Drawing.Color.Transparent;
            this.lblKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKhuyenMai.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.lblKhuyenMai.Location = new System.Drawing.Point(720, 12);
            this.lblKhuyenMai.Name = "lblKhuyenMai";
            this.lblKhuyenMai.Size = new System.Drawing.Size(88, 19);
            this.lblKhuyenMai.TabIndex = 4;
            this.lblKhuyenMai.Text = "Khuyến mãi: -";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.FillColor = System.Drawing.Color.White;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContent.Size = new System.Drawing.Size(1072, 474);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.Controls.Add(this.dgvChiTiet);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(24, 24);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.Size = new System.Drawing.Size(1024, 426);
            this.dgvChiTiet.TabIndex = 0;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvChiTiet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvChiTiet.ThemeStyle.RowsStyle.Height = 28;
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            // Header style
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTiet.ColumnHeadersHeight = 36;
            // Default style
            defaultStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = System.Drawing.Color.White;
            defaultStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            defaultStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            defaultStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            defaultStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            defaultStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = defaultStyle;
            // Alternating style
            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 252);
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = alternatingStyle;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvChiTiet.AutoGenerateColumns = true; // dữ liệu DataTable sẽ tự bind các cột
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.FillColor = System.Drawing.Color.White;
            this.pnlFooter.Location = new System.Drawing.Point(0, 554);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1072, 60);
            this.pnlFooter.TabIndex = 2;
            this.pnlFooter.Controls.Add(this.btnClose);
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(920, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 251, 252);
            this.ClientSize = new System.Drawing.Size(1072, 614);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmChiTietHoaDon";
            this.Text = "Chi tiết hóa đơn";
            this.Load += new System.EventHandler(this.FrmChiTietHoaDon_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaHD;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongTien;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKhuyenMai;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}