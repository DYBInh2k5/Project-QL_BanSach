namespace QLBanSach_GUI.UserControls
{
    partial class UC_TheLoaiSach
    {
        private System.ComponentModel.IContainer components = null;

        // NEW: Context menu components
        private System.Windows.Forms.ContextMenuStrip cmsTheLoai;
        private System.Windows.Forms.ToolStripMenuItem miThemTheLoai;
        private System.Windows.Forms.ToolStripMenuItem miDoiTen;
        private System.Windows.Forms.ToolStripMenuItem miXoa;
        private System.Windows.Forms.ToolStripMenuItem miLamMoi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvTheLoai = new System.Windows.Forms.TreeView();
            this.lvSach = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.picAnhTo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();

            // NEW: Context menu init
            this.cmsTheLoai = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miThemTheLoai = new System.Windows.Forms.ToolStripMenuItem();
            this.miDoiTen = new System.Windows.Forms.ToolStripMenuItem();
            this.miXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.miLamMoi = new System.Windows.Forms.ToolStripMenuItem();

            ((System.ComponentModel.ISupportInitialize)(this.picAnhTo)).BeginInit();
            this.SuspendLayout();
            // 
            // tvTheLoai
            // 
            this.tvTheLoai.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvTheLoai.Location = new System.Drawing.Point(0, 0);
            this.tvTheLoai.Name = "tvTheLoai";
            this.tvTheLoai.Size = new System.Drawing.Size(280, 572);
            this.tvTheLoai.TabIndex = 0;
            this.tvTheLoai.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTheLoai_AfterSelect);
            // attach context menu
            this.tvTheLoai.ContextMenuStrip = this.cmsTheLoai;
            // 
            // lvSach
            // 
            this.lvSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSach.HideSelection = false;
            this.lvSach.LargeImageList = this.imageList1;
            this.lvSach.Location = new System.Drawing.Point(280, 0);
            this.lvSach.Name = "lvSach";
            this.lvSach.Size = new System.Drawing.Size(716, 572);
            this.lvSach.TabIndex = 1;
            this.lvSach.UseCompatibleStateImageBehavior = false;
            this.lvSach.View = System.Windows.Forms.View.Details;
            // UX improvements
            this.lvSach.FullRowSelect = true;
            this.lvSach.GridLines = true;
            this.lvSach.MultiSelect = true;
            this.lvSach.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã sách";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sách";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tác giả";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 120;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(60, 80);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnThem
            // 
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(816, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(180, 32);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm sách";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(648, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // picAnhTo
            // 
            this.picAnhTo.ImageRotate = 0F;
            this.picAnhTo.Location = new System.Drawing.Point(280, 48);
            this.picAnhTo.Name = "picAnhTo";
            this.picAnhTo.Size = new System.Drawing.Size(300, 160);
            this.picAnhTo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhTo.TabIndex = 4;
            this.picAnhTo.TabStop = false;
            this.picAnhTo.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(286, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm theo tên sách...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(356, 32);
            this.txtSearch.TabIndex = 5;

            // NEW: ContextMenuStrip items
            this.cmsTheLoai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miThemTheLoai,
                this.miDoiTen,
                this.miXoa,
                this.miLamMoi
            });
            this.cmsTheLoai.Name = "cmsTheLoai";
            this.cmsTheLoai.Size = new System.Drawing.Size(181, 114);

            // miThemTheLoai
            this.miThemTheLoai.Name = "miThemTheLoai";
            this.miThemTheLoai.Size = new System.Drawing.Size(180, 22);
            this.miThemTheLoai.Text = "Thêm thể loại";
            this.miThemTheLoai.Click += new System.EventHandler(this.miThemTheLoai_Click);
            // miDoiTen
            this.miDoiTen.Name = "miDoiTen";
            this.miDoiTen.Size = new System.Drawing.Size(180, 22);
            this.miDoiTen.Text = "Đổi tên";
            this.miDoiTen.Click += new System.EventHandler(this.miDoiTen_Click);
            // miXoa
            this.miXoa.Name = "miXoa";
            this.miXoa.Size = new System.Drawing.Size(180, 22);
            this.miXoa.Text = "Xóa";
            this.miXoa.Click += new System.EventHandler(this.miXoa_Click);
            // miLamMoi
            this.miLamMoi.Name = "miLamMoi";
            this.miLamMoi.Size = new System.Drawing.Size(180, 22);
            this.miLamMoi.Text = "Làm mới";
            this.miLamMoi.Click += new System.EventHandler(this.miLamMoi_Click);

            // 
            // UC_TheLoaiSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvSach);
            this.Controls.Add(this.tvTheLoai);
            this.Name = "UC_TheLoaiSach";
            this.Size = new System.Drawing.Size(996, 572);
            this.Load += new System.EventHandler(this.UC_TheLoaiSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhTo)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TreeView tvTheLoai;
        private System.Windows.Forms.ListView lvSach;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2PictureBox picAnhTo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    }
}
