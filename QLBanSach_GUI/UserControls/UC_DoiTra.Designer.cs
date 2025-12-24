namespace QLBanSach_GUI.UserControls
{
    partial class UC_DoiTra
    {
        private System.ComponentModel.IContainer components = null;

        // Controls khớp với code-behind
        private System.Windows.Forms.SplitContainer splitMain;

        private System.Windows.Forms.GroupBox grpHoaDon;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Button btnLoadHD;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblSearchHD;
        private System.Windows.Forms.TextBox txtSearchHD;
        private System.Windows.Forms.DataGridView dgvSachDoiTra;

        private System.Windows.Forms.GroupBox grpLyDo;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.RadioButton rbDoiSach;
        private System.Windows.Forms.RadioButton rbTraHangHoanTien;

        private System.Windows.Forms.GroupBox grpThaoTac;
        private System.Windows.Forms.Label lblNumSL;
        private System.Windows.Forms.NumericUpDown numSLDoiTra;
        private System.Windows.Forms.Button btnSetSLDoi;
        private System.Windows.Forms.Button btnClearSelected;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnXacNhan;

        private System.Windows.Forms.GroupBox grpTatCaSach;
        private System.Windows.Forms.Label lblFindBook;
        private System.Windows.Forms.TextBox txtFindBook;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private System.Windows.Forms.DataGridView dgvTatCaSach;

            private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSL;
        private System.Windows.Forms.ToolStripStatusLabel lblTongTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.btnLoadHD = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblSearchHD = new System.Windows.Forms.Label();
            this.txtSearchHD = new System.Windows.Forms.TextBox();
            this.dgvSachDoiTra = new System.Windows.Forms.DataGridView();
            this.grpLyDo = new System.Windows.Forms.GroupBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.rbDoiSach = new System.Windows.Forms.RadioButton();
            this.rbTraHangHoanTien = new System.Windows.Forms.RadioButton();
            this.grpThaoTac = new System.Windows.Forms.GroupBox();
            this.lblNumSL = new System.Windows.Forms.Label();
            this.numSLDoiTra = new System.Windows.Forms.NumericUpDown();
            this.btnSetSLDoi = new System.Windows.Forms.Button();
            this.btnClearSelected = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.grpTatCaSach = new System.Windows.Forms.GroupBox();
            this.lblFindBook = new System.Windows.Forms.Label();
            this.txtFindBook = new System.Windows.Forms.TextBox();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.cbTheLoai = new System.Windows.Forms.ComboBox();
            this.dgvTatCaSach = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblTongSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTongTien = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachDoiTra)).BeginInit();
            this.grpLyDo.SuspendLayout();
            this.grpThaoTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSLDoiTra)).BeginInit();
            this.grpTatCaSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTatCaSach)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grpHoaDon);
            this.splitMain.Panel1.Controls.Add(this.grpLyDo);
            this.splitMain.Panel1.Controls.Add(this.grpThaoTac);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grpTatCaSach);
            this.splitMain.Size = new System.Drawing.Size(1100, 658);
            this.splitMain.SplitterDistance = 740;
            this.splitMain.TabIndex = 0;
            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHoaDon.Controls.Add(this.lblMaHD);
            this.grpHoaDon.Controls.Add(this.txtMaHD);
            this.grpHoaDon.Controls.Add(this.btnLoadHD);
            this.grpHoaDon.Controls.Add(this.lblFrom);
            this.grpHoaDon.Controls.Add(this.dtFrom);
            this.grpHoaDon.Controls.Add(this.lblTo);
            this.grpHoaDon.Controls.Add(this.dtTo);
            this.grpHoaDon.Controls.Add(this.lblSearchHD);
            this.grpHoaDon.Controls.Add(this.txtSearchHD);
            this.grpHoaDon.Controls.Add(this.dgvSachDoiTra);
            this.grpHoaDon.Location = new System.Drawing.Point(8, 8);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Size = new System.Drawing.Size(724, 330);
            this.grpHoaDon.TabIndex = 0;
            this.grpHoaDon.TabStop = false;
            this.grpHoaDon.Text = "Sách trong hóa đơn";
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(12, 28);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(44, 13);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã HĐ:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(66, 24);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(120, 20);
            this.txtMaHD.TabIndex = 1;
            // 
            // btnLoadHD
            // 
            this.btnLoadHD.Location = new System.Drawing.Point(192, 23);
            this.btnLoadHD.Name = "btnLoadHD";
            this.btnLoadHD.Size = new System.Drawing.Size(98, 26);
            this.btnLoadHD.TabIndex = 2;
            this.btnLoadHD.Text = "Tải hóa đơn";
            this.btnLoadHD.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(310, 28);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(49, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(370, 24);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(120, 20);
            this.dtFrom.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(500, 28);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(56, 13);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "Đến ngày:";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(570, 24);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(120, 20);
            this.dtTo.TabIndex = 6;
            // 
            // lblSearchHD
            // 
            this.lblSearchHD.AutoSize = true;
            this.lblSearchHD.Location = new System.Drawing.Point(12, 60);
            this.lblSearchHD.Name = "lblSearchHD";
            this.lblSearchHD.Size = new System.Drawing.Size(53, 13);
            this.lblSearchHD.TabIndex = 7;
            this.lblSearchHD.Text = "Tìm sách:";
            // 
            // txtSearchHD
            // 
            this.txtSearchHD.Location = new System.Drawing.Point(82, 56);
            this.txtSearchHD.Name = "txtSearchHD";
            this.txtSearchHD.Size = new System.Drawing.Size(300, 20);
            this.txtSearchHD.TabIndex = 8;
            // 
            // dgvSachDoiTra
            // 
            this.dgvSachDoiTra.AllowUserToAddRows = false;
            this.dgvSachDoiTra.AllowUserToDeleteRows = false;
            this.dgvSachDoiTra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSachDoiTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachDoiTra.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSachDoiTra.Location = new System.Drawing.Point(15, 88);
            this.dgvSachDoiTra.MultiSelect = false;
            this.dgvSachDoiTra.Name = "dgvSachDoiTra";
            this.dgvSachDoiTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachDoiTra.Size = new System.Drawing.Size(694, 230);
            this.dgvSachDoiTra.TabIndex = 9;
            // 
            // grpLyDo
            // 
            this.grpLyDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLyDo.Controls.Add(this.lblLyDo);
            this.grpLyDo.Controls.Add(this.txtLyDo);
            this.grpLyDo.Controls.Add(this.lblGhiChu);
            this.grpLyDo.Controls.Add(this.txtGhiChu);
            this.grpLyDo.Controls.Add(this.rbDoiSach);
            this.grpLyDo.Controls.Add(this.rbTraHangHoanTien);
            this.grpLyDo.Location = new System.Drawing.Point(8, 345);
            this.grpLyDo.Name = "grpLyDo";
            this.grpLyDo.Size = new System.Drawing.Size(724, 120);
            this.grpLyDo.TabIndex = 1;
            this.grpLyDo.TabStop = false;
            this.grpLyDo.Text = "Thông tin đổi/trả";
            this.grpLyDo.Enter += new System.EventHandler(this.grpLyDo_Enter);
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(12, 28);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(36, 13);
            this.lblLyDo.TabIndex = 0;
            this.lblLyDo.Text = "Lý do:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(60, 24);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(300, 20);
            this.txtLyDo.TabIndex = 1;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(370, 28);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(430, 24);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(280, 20);
            this.txtGhiChu.TabIndex = 3;
            // 
            // rbDoiSach
            // 
            this.rbDoiSach.AutoSize = true;
            this.rbDoiSach.Checked = true;
            this.rbDoiSach.Location = new System.Drawing.Point(60, 60);
            this.rbDoiSach.Name = "rbDoiSach";
            this.rbDoiSach.Size = new System.Drawing.Size(67, 17);
            this.rbDoiSach.TabIndex = 4;
            this.rbDoiSach.TabStop = true;
            this.rbDoiSach.Text = "Đổi sách";
            // 
            // rbTraHangHoanTien
            // 
            this.rbTraHangHoanTien.AutoSize = true;
            this.rbTraHangHoanTien.Location = new System.Drawing.Point(160, 60);
            this.rbTraHangHoanTien.Name = "rbTraHangHoanTien";
            this.rbTraHangHoanTien.Size = new System.Drawing.Size(115, 17);
            this.rbTraHangHoanTien.TabIndex = 5;
            this.rbTraHangHoanTien.Text = "Trả hàng hoàn tiền";
            // 
            // grpThaoTac
            // 
            this.grpThaoTac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThaoTac.Controls.Add(this.lblNumSL);
            this.grpThaoTac.Controls.Add(this.numSLDoiTra);
            this.grpThaoTac.Controls.Add(this.btnSetSLDoi);
            this.grpThaoTac.Controls.Add(this.btnClearSelected);
            this.grpThaoTac.Controls.Add(this.btnReset);
            this.grpThaoTac.Controls.Add(this.btnExportCSV);
            this.grpThaoTac.Controls.Add(this.btnXacNhan);
            this.grpThaoTac.Location = new System.Drawing.Point(8, 470);
            this.grpThaoTac.Name = "grpThaoTac";
            this.grpThaoTac.Size = new System.Drawing.Size(724, 120);
            this.grpThaoTac.TabIndex = 2;
            this.grpThaoTac.TabStop = false;
            this.grpThaoTac.Text = "Thao tác";
            // 
            // lblNumSL
            // 
            this.lblNumSL.AutoSize = true;
            this.lblNumSL.Location = new System.Drawing.Point(12, 32);
            this.lblNumSL.Name = "lblNumSL";
            this.lblNumSL.Size = new System.Drawing.Size(91, 13);
            this.lblNumSL.TabIndex = 0;
            this.lblNumSL.Text = "SL đổi/trả (dòng):";
            // 
            // numSLDoiTra
            // 
            this.numSLDoiTra.Location = new System.Drawing.Point(120, 28);
            this.numSLDoiTra.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSLDoiTra.Name = "numSLDoiTra";
            this.numSLDoiTra.Size = new System.Drawing.Size(80, 20);
            this.numSLDoiTra.TabIndex = 1;
            // 
            // btnSetSLDoi
            // 
            this.btnSetSLDoi.Location = new System.Drawing.Point(210, 27);
            this.btnSetSLDoi.Name = "btnSetSLDoi";
            this.btnSetSLDoi.Size = new System.Drawing.Size(110, 26);
            this.btnSetSLDoi.TabIndex = 2;
            this.btnSetSLDoi.Text = "Đặt SL cho dòng";
            this.btnSetSLDoi.UseVisualStyleBackColor = true;
            // 
            // btnClearSelected
            // 
            this.btnClearSelected.Location = new System.Drawing.Point(330, 27);
            this.btnClearSelected.Name = "btnClearSelected";
            this.btnClearSelected.Size = new System.Drawing.Size(110, 26);
            this.btnClearSelected.TabIndex = 3;
            this.btnClearSelected.Text = "Bỏ chọn";
            this.btnClearSelected.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(450, 27);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 26);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Location = new System.Drawing.Point(546, 27);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(84, 26);
            this.btnExportCSV.TabIndex = 5;
            this.btnExportCSV.Text = "Xuất CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(636, 27);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(80, 26);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // grpTatCaSach
            // 
            this.grpTatCaSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTatCaSach.Controls.Add(this.lblFindBook);
            this.grpTatCaSach.Controls.Add(this.txtFindBook);
            this.grpTatCaSach.Controls.Add(this.lblTheLoai);
            this.grpTatCaSach.Controls.Add(this.cbTheLoai);
            this.grpTatCaSach.Controls.Add(this.dgvTatCaSach);
            this.grpTatCaSach.Location = new System.Drawing.Point(8, 8);
            this.grpTatCaSach.Name = "grpTatCaSach";
            this.grpTatCaSach.Size = new System.Drawing.Size(330, 582);
            this.grpTatCaSach.TabIndex = 0;
            this.grpTatCaSach.TabStop = false;
            this.grpTatCaSach.Text = "Danh mục sách (tham khảo)";
            // 
            // lblFindBook
            // 
            this.lblFindBook.AutoSize = true;
            this.lblFindBook.Location = new System.Drawing.Point(12, 28);
            this.lblFindBook.Name = "lblFindBook";
            this.lblFindBook.Size = new System.Drawing.Size(53, 13);
            this.lblFindBook.TabIndex = 0;
            this.lblFindBook.Text = "Tìm sách:";
            // 
            // txtFindBook
            // 
            this.txtFindBook.Location = new System.Drawing.Point(82, 24);
            this.txtFindBook.Name = "txtFindBook";
            this.txtFindBook.Size = new System.Drawing.Size(230, 20);
            this.txtFindBook.TabIndex = 1;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Location = new System.Drawing.Point(12, 60);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(48, 13);
            this.lblTheLoai.TabIndex = 2;
            this.lblTheLoai.Text = "Thể loại:";
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheLoai.Location = new System.Drawing.Point(82, 56);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(230, 21);
            this.cbTheLoai.TabIndex = 3;
            // 
            // dgvTatCaSach
            // 
            this.dgvTatCaSach.AllowUserToAddRows = false;
            this.dgvTatCaSach.AllowUserToDeleteRows = false;
            this.dgvTatCaSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTatCaSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTatCaSach.Location = new System.Drawing.Point(15, 88);
            this.dgvTatCaSach.Name = "dgvTatCaSach";
            this.dgvTatCaSach.ReadOnly = true;
            this.dgvTatCaSach.Size = new System.Drawing.Size(300, 480);
            this.dgvTatCaSach.TabIndex = 4;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongSL,
            this.lblTongTien});
            this.statusStrip.Location = new System.Drawing.Point(0, 658);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // lblTongSL
            // 
            this.lblTongSL.Name = "lblTongSL";
            this.lblTongSL.Size = new System.Drawing.Size(82, 17);
            this.lblTongSL.Text = "Tổng SL đổi: 0";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(70, 17);
            this.lblTongTien.Text = "Tổng tiền: 0";
            // 
            // UC_DoiTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStrip);
            this.Name = "UC_DoiTra";
            this.Size = new System.Drawing.Size(1100, 680);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachDoiTra)).EndInit();
            this.grpLyDo.ResumeLayout(false);
            this.grpLyDo.PerformLayout();
            this.grpThaoTac.ResumeLayout(false);
            this.grpThaoTac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSLDoiTra)).EndInit();
            this.grpTatCaSach.ResumeLayout(false);
            this.grpTatCaSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTatCaSach)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
