namespace QLBanSach_GUI.UserControls
{
    partial class UC_NhanSu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddNV = new System.Windows.Forms.ToolStripButton();
            this.btnEditNV = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteNV = new System.Windows.Forms.ToolStripButton();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddBangCap = new System.Windows.Forms.ToolStripButton();
            this.btnAddKinhNghiem = new System.Windows.Forms.ToolStripButton();
            this.btnAddCongTac = new System.Windows.Forms.ToolStripButton();
            this.btnThiDua = new System.Windows.Forms.ToolStripButton();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddTaiLieu = new System.Windows.Forms.ToolStripButton();
            this.btnOpenTaiLieu = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTaiLieu = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lvData = new System.Windows.Forms.ListView();
            this.Tên = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ngày = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GhiChu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.btnSearch,
            this.btnRefresh,
            this.sep1,
            this.btnAddNV,
            this.btnEditNV,
            this.btnDeleteNV,
            this.sep2,
            this.btnAddBangCap,
            this.btnAddKinhNghiem,
            this.btnAddCongTac,
            this.btnThiDua,
            this.sep3,
            this.btnAddTaiLieu,
            this.btnOpenTaiLieu,
            this.btnDeleteTaiLieu});
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1201, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.ToolTipText = "Tìm nhân viên theo tên";
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAddNV
            // 
            this.btnAddNV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddNV.Name = "btnAddNV";
            this.btnAddNV.Text = "Thêm NV";
            this.btnAddNV.Click += new System.EventHandler(this.btnAddNV_Click);
            // 
            // btnEditNV
            // 
            this.btnEditNV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditNV.Name = "btnEditNV";
            this.btnEditNV.Text = "Sửa NV";
            this.btnEditNV.Click += new System.EventHandler(this.btnEditNV_Click);
            // 
            // btnDeleteNV
            // 
            this.btnDeleteNV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeleteNV.Name = "btnDeleteNV";
            this.btnDeleteNV.Text = "Xóa NV";
            this.btnDeleteNV.Click += new System.EventHandler(this.btnDeleteNV_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAddBangCap
            // 
            this.btnAddBangCap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddBangCap.Name = "btnAddBangCap";
            this.btnAddBangCap.Text = "Thêm bằng cấp";
            this.btnAddBangCap.ToolTipText = "Thêm bằng cấp cho nhân viên đang chọn";
            this.btnAddBangCap.Click += new System.EventHandler(this.btnAddBangCap_Click);
            // 
            // btnAddKinhNghiem
            // 
            this.btnAddKinhNghiem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddKinhNghiem.Name = "btnAddKinhNghiem";
            this.btnAddKinhNghiem.Text = "Thêm kinh nghiệm";
            this.btnAddKinhNghiem.ToolTipText = "Thêm kinh nghiệm cho nhân viên đang chọn";
            this.btnAddKinhNghiem.Click += new System.EventHandler(this.btnAddKinhNghiem_Click);
            // 
            // btnAddCongTac
            // 
            this.btnAddCongTac.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddCongTac.Name = "btnAddCongTac";
            this.btnAddCongTac.Text = "Thêm công tác";
            this.btnAddCongTac.ToolTipText = "Thêm lịch sử công tác cho nhân viên đang chọn";
            this.btnAddCongTac.Click += new System.EventHandler(this.btnAddCongTac_Click);
            // 
            // btnThiDua
            // 
            this.btnThiDua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnThiDua.Name = "btnThiDua";
            this.btnThiDua.Text = "Thi đua";
            this.btnThiDua.ToolTipText = "Xem bảng thi đua bán hàng";
            this.btnThiDua.Click += new System.EventHandler(this.btnThiDua_Click);
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAddTaiLieu
            // 
            this.btnAddTaiLieu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddTaiLieu.Name = "btnAddTaiLieu";
            this.btnAddTaiLieu.Text = "Thêm tài liệu";
            this.btnAddTaiLieu.ToolTipText = "Tải tài liệu đính kèm cho nhân viên";
            this.btnAddTaiLieu.Click += new System.EventHandler(this.btnAddTaiLieu_Click);
            // 
            // btnOpenTaiLieu
            // 
            this.btnOpenTaiLieu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenTaiLieu.Name = "btnOpenTaiLieu";
            this.btnOpenTaiLieu.Text = "Mở";
            this.btnOpenTaiLieu.ToolTipText = "Mở tài liệu đang chọn";
            this.btnOpenTaiLieu.Click += new System.EventHandler(this.btnOpenTaiLieu_Click);
            // 
            // btnDeleteTaiLieu
            // 
            this.btnDeleteTaiLieu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeleteTaiLieu.Name = "btnDeleteTaiLieu";
            this.btnDeleteTaiLieu.Text = "Xóa TL";
            this.btnDeleteTaiLieu.ToolTipText = "Xóa tài liệu đang chọn";
            this.btnDeleteTaiLieu.Click += new System.EventHandler(this.btnDeleteTaiLieu_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvMenu);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1201, 600);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // tvMenu
            // 
            this.tvMenu.Location = new System.Drawing.Point(12, 12);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.Size = new System.Drawing.Size(320, 560);
            this.tvMenu.TabIndex = 0;
            this.tvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterSelect);
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Controls.Add(this.dgvData);
            this.panelRight.Controls.Add(this.lvData);
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(847, 600);
            this.panelRight.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.MultiSelect = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.TabIndex = 2;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tên,
            this.Ngày,
            this.GhiChu});
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(12, 12);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(489, 379);
            this.lvData.TabIndex = 1;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            this.lvData.Visible = false; // legacy list, will be switched to thumbnails for Tài liệu
            this.lvData.SelectedIndexChanged += new System.EventHandler(this.lvData_SelectedIndexChanged);
            // 
            // Tên
            // 
            this.Tên.Text = "Tên";
            this.Tên.Width = 200;
            // 
            // Ngày
            // 
            this.Ngày.Text = "Ngày";
            this.Ngày.Width = 120;
            // 
            // GhiChu
            // 
            this.GhiChu.Text = "Ghi chú";
            this.GhiChu.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UC_NhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UC_NhanSu";
            this.Size = new System.Drawing.Size(1201, 627);
            this.Load += new System.EventHandler(this.UC_NhanSu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripButton btnAddNV;
        private System.Windows.Forms.ToolStripButton btnEditNV;
        private System.Windows.Forms.ToolStripButton btnDeleteNV;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripButton btnAddBangCap;
        private System.Windows.Forms.ToolStripButton btnAddKinhNghiem;
        private System.Windows.Forms.ToolStripButton btnAddCongTac;
        private System.Windows.Forms.ToolStripButton btnThiDua;
        private System.Windows.Forms.ToolStripSeparator sep3;
        private System.Windows.Forms.ToolStripButton btnAddTaiLieu;
        private System.Windows.Forms.ToolStripButton btnOpenTaiLieu;
        private System.Windows.Forms.ToolStripButton btnDeleteTaiLieu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader Tên;
        private System.Windows.Forms.ColumnHeader Ngày;
        private System.Windows.Forms.ColumnHeader GhiChu;
        private System.Windows.Forms.ImageList imageList1;
    }
}
