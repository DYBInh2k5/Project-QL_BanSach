namespace QLBanSach_GUI.UserControls
{
    partial class UC_NhapKho
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvSach;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchBook;
        private System.Windows.Forms.Button btnSearchBook;

        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnThemVaoPhieu;

        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblMaPN;
        private System.Windows.Forms.TextBox txtMaPN;

        private System.Windows.Forms.ListView lvNhapKho;
        private System.Windows.Forms.ColumnHeader colMaSach;
        private System.Windows.Forms.ColumnHeader colTenSach;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colDonGia;
        private System.Windows.Forms.ColumnHeader colThanhTien;

        private System.Windows.Forms.Label lblTongTienText;
        private System.Windows.Forms.Label lblTongTien;

        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnXoaChiTiet;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnImportExcel;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

        private System.Windows.Forms.Panel pnlProgressContainer;
        private System.Windows.Forms.ProgressBar progressBarNhapKho;
        private System.Windows.Forms.Label lblProgressStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvSach = new System.Windows.Forms.DataGridView();

            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.btnSearchBook = new System.Windows.Forms.Button();

            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnThemVaoPhieu = new System.Windows.Forms.Button();

            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblMaPN = new System.Windows.Forms.Label();
            this.txtMaPN = new System.Windows.Forms.TextBox();

            this.lvNhapKho = new System.Windows.Forms.ListView();
            this.colMaSach = new System.Windows.Forms.ColumnHeader();
            this.colTenSach = new System.Windows.Forms.ColumnHeader();
            this.colSoLuong = new System.Windows.Forms.ColumnHeader();
            this.colDonGia = new System.Windows.Forms.ColumnHeader();
            this.colThanhTien = new System.Windows.Forms.ColumnHeader();

            this.lblTongTienText = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();

            this.btnNhapKho = new System.Windows.Forms.Button();
            this.btnXoaChiTiet = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();

            this.pnlProgressContainer = new System.Windows.Forms.Panel();
            this.progressBarNhapKho = new System.Windows.Forms.ProgressBar();
            this.lblProgressStatus = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();

            this.statusStrip.SuspendLayout();
            this.pnlProgressContainer.SuspendLayout();

            this.SuspendLayout();

            // splitMain
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitMain.SplitterDistance = 480;
            this.splitMain.TabIndex = 0;

            // Left panel
            this.splitMain.Panel1.Controls.Add(this.lblSearch);
            this.splitMain.Panel1.Controls.Add(this.txtSearchBook);
            this.splitMain.Panel1.Controls.Add(this.btnSearchBook);
            this.splitMain.Panel1.Controls.Add(this.lblSoLuong);
            this.splitMain.Panel1.Controls.Add(this.txtSoLuong);
            this.splitMain.Panel1.Controls.Add(this.lblDonGia);
            this.splitMain.Panel1.Controls.Add(this.txtDonGia);
            this.splitMain.Panel1.Controls.Add(this.btnThemVaoPhieu);
            this.splitMain.Panel1.Controls.Add(this.dgvSach);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(78, 13);
            this.lblSearch.Text = "Tìm kiếm sách:";

            // txtSearchBook
            this.txtSearchBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBook.Location = new System.Drawing.Point(15, 30);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(360, 20);
            this.txtSearchBook.TabIndex = 0;

            // btnSearchBook
            this.btnSearchBook.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnSearchBook.Location = new System.Drawing.Point(381, 28);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(85, 23);
            this.btnSearchBook.Text = "Tìm";
            this.btnSearchBook.UseVisualStyleBackColor = true;
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);

            // lblSoLuong
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(12, 60);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(57, 13);
            this.lblSoLuong.Text = "Số lượng:";

            // txtSoLuong
            this.txtSoLuong.Location = new System.Drawing.Point(75, 57);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(60, 20);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.Text = "1";

            // lblDonGia
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(150, 60);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(49, 13);
            this.lblDonGia.Text = "Đơn giá:";

            // txtDonGia
            this.txtDonGia.Location = new System.Drawing.Point(205, 57);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 20);
            this.txtDonGia.TabIndex = 2;
            this.txtDonGia.Text = "0";

            // btnThemVaoPhieu
            this.btnThemVaoPhieu.Location = new System.Drawing.Point(315, 55);
            this.btnThemVaoPhieu.Name = "btnThemVaoPhieu";
            this.btnThemVaoPhieu.Size = new System.Drawing.Size(151, 23);
            this.btnThemVaoPhieu.Text = "Thêm vào phiếu";
            this.btnThemVaoPhieu.UseVisualStyleBackColor = true;
            this.btnThemVaoPhieu.Click += new System.EventHandler(this.btnThemVaoPhieu_Click);

            // dgvSach
            this.dgvSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSach.Location = new System.Drawing.Point(15, 90);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.RowHeadersVisible = false;
            this.dgvSach.Size = new System.Drawing.Size(451, 420);
            this.dgvSach.TabIndex = 3;
            this.dgvSach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellDoubleClick);

            // Right panel
            this.splitMain.Panel2.Controls.Add(this.lblNhanVien);
            this.splitMain.Panel2.Controls.Add(this.cboNhanVien);
            this.splitMain.Panel2.Controls.Add(this.lblNgayNhap);
            this.splitMain.Panel2.Controls.Add(this.dtpNgayNhap);
            this.splitMain.Panel2.Controls.Add(this.lblMaPN);
            this.splitMain.Panel2.Controls.Add(this.txtMaPN);

            this.splitMain.Panel2.Controls.Add(this.lvNhapKho);
            this.splitMain.Panel2.Controls.Add(this.lblTongTienText);
            this.splitMain.Panel2.Controls.Add(this.lblTongTien);
            this.splitMain.Panel2.Controls.Add(this.btnNhapKho);
            this.splitMain.Panel2.Controls.Add(this.btnXoaChiTiet);
            this.splitMain.Panel2.Controls.Add(this.btnExportExcel);
            this.splitMain.Panel2.Controls.Add(this.btnImportExcel);

            this.splitMain.Panel2.Controls.Add(this.pnlProgressContainer);
            this.splitMain.Panel2.Controls.Add(this.statusStrip);

            // Header right
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(12, 12);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(60, 13);
            this.lblNhanVien.Text = "Nhân viên:";

            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Location = new System.Drawing.Point(78, 9);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(180, 21);
            this.cboNhanVien.TabIndex = 4;

            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(268, 12);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(62, 13);
            this.lblNgayNhap.Text = "Ngày nhập:";

            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(336, 9);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(100, 20);
            this.dtpNgayNhap.TabIndex = 5;

            this.lblMaPN.AutoSize = true;
            this.lblMaPN.Location = new System.Drawing.Point(444, 12);
            this.lblMaPN.Name = "lblMaPN";
            this.lblMaPN.Size = new System.Drawing.Size(77, 13);
            this.lblMaPN.Text = "Mã phiếu nhập:";

               this.txtMaPN.Location = new System.Drawing.Point(527, 9);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.ReadOnly = true;
            this.txtMaPN.Size = new System.Drawing.Size(90, 20);
            this.txtMaPN.TabIndex = 6;

            // ListView
            this.lvNhapKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvNhapKho.Location = new System.Drawing.Point(15, 40);
            this.lvNhapKho.Name = "lvNhapKho";
            this.lvNhapKho.Size = new System.Drawing.Size(820, 400);
            this.lvNhapKho.View = System.Windows.Forms.View.Details;
            this.lvNhapKho.FullRowSelect = true;
            this.lvNhapKho.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colMaSach, this.colTenSach, this.colSoLuong, this.colDonGia, this.colThanhTien
            });

            this.colMaSach.Text = "Mã sách";
            this.colMaSach.Width = 100;
            this.colTenSach.Text = "Tên sách";
            this.colTenSach.Width = 300;
            this.colSoLuong.Text = "Số lượng";
            this.colSoLuong.Width = 100;
            this.colDonGia.Text = "Đơn giá";
            this.colDonGia.Width = 150;
            this.colThanhTien.Text = "Thành tiền";
            this.colThanhTien.Width = 150;

            // Total and actions
            this.lblTongTienText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTienText.AutoSize = true;
            this.lblTongTienText.Location = new System.Drawing.Point(12, 447);
            this.lblTongTienText.Text = "Tổng tiền:";

            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(70, 447);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(28, 13);
            this.lblTongTien.Text = "0 VNĐ";

            this.btnNhapKho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhapKho.Location = new System.Drawing.Point(750, 443);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(85, 25);
            this.btnNhapKho.Text = "Nhập kho";
            this.btnNhapKho.UseVisualStyleBackColor = true;
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);

            this.btnXoaChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaChiTiet.Location = new System.Drawing.Point(655, 443);
            this.btnXoaChiTiet.Name = "btnXoaChiTiet";
            this.btnXoaChiTiet.Size = new System.Drawing.Size(85, 25);
            this.btnXoaChiTiet.Text = "Xóa dòng";
            this.btnXoaChiTiet.UseVisualStyleBackColor = true;
            this.btnXoaChiTiet.Click += new System.EventHandler(this.btnXoaChiTiet_Click);

            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(560, 443);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(85, 25);
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportExcel.Location = new System.Drawing.Point(465, 443);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(85, 25);
            this.btnImportExcel.Text = "Nhập Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);

            // Progress panel
            this.pnlProgressContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlProgressContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgressContainer.Location = new System.Drawing.Point(150, 438);
            this.pnlProgressContainer.Name = "pnlProgressContainer";
            this.pnlProgressContainer.Size = new System.Drawing.Size(300, 34);
            this.pnlProgressContainer.Visible = false;

            this.progressBarNhapKho.Location = new System.Drawing.Point(6, 6);
            this.progressBarNhapKho.Name = "progressBarNhapKho";
            this.progressBarNhapKho.Size = new System.Drawing.Size(180, 20);
            this.progressBarNhapKho.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Location = new System.Drawing.Point(195, 9);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(73, 13);
            this.lblProgressStatus.Text = "Đang xử lý...";

            this.pnlProgressContainer.Controls.Add(this.progressBarNhapKho);
            this.pnlProgressContainer.Controls.Add(this.lblProgressStatus);

            // StatusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.statusLabel
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 470);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1350, 22);

            this.statusLabel.Text = "Sẵn sàng";

            // UC_NhapKho
            this.Controls.Add(this.splitMain);
            this.Name = "UC_NhapKho";
            this.Size = new System.Drawing.Size(1350, 492);
            this.Load += new System.EventHandler(this.UC_NhapKho_Load);
            this.splitMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitMain_SplitterMoved);

            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();

            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlProgressContainer.ResumeLayout(false);
            this.pnlProgressContainer.PerformLayout();

            this.ResumeLayout(false);
        }
    }
}
