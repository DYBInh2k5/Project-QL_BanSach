namespace QLBanSach_GUI
{
    partial class FrmPlayground
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SplitContainer splitMain;

        private System.Windows.Forms.TreeView tvCategories;
        private System.Windows.Forms.ProgressBar progressBar;

        private System.Windows.Forms.TableLayoutPanel tableLayoutRight;
        private System.Windows.Forms.FlowLayoutPanel flowTop;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.Button btnChooseImage;

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.DateTimePicker dtPicker;

        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ImageList imageList;

        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem mOpen;
        private System.Windows.Forms.ToolStripMenuItem mExit;
        private System.Windows.Forms.ToolStripMenuItem mView;
        private System.Windows.Forms.ToolStripMenuItem mTile;
        private System.Windows.Forms.ToolStripMenuItem mDetails;
        private System.Windows.Forms.ToolStripMenuItem mHelp;
        private System.Windows.Forms.ToolStripMenuItem mAbout;

        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripButton tsExport;
        private System.Windows.Forms.ToolStripButton tsRunTask;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                imageList?.Dispose();
                pbPreview?.Image?.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mView = new System.Windows.Forms.ToolStripMenuItem();
            this.mTile = new System.Windows.Forms.ToolStripMenuItem();
            this.mDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsExport = new System.Windows.Forms.ToolStripButton();
            this.tsRunTask = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tvCategories = new System.Windows.Forms.TreeView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutRight = new System.Windows.Forms.TableLayoutPanel();
            this.flowTop = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.lvItems = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tableLayoutRight.SuspendLayout();
            this.flowTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mView,
            this.mHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpen,
            this.mExit});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(37, 20);
            this.mFile.Text = "&File";
            // 
            // mOpen
            // 
            this.mOpen.Name = "mOpen";
            this.mOpen.Size = new System.Drawing.Size(112, 22);
            this.mOpen.Text = "&Open...";
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.Size = new System.Drawing.Size(112, 22);
            this.mExit.Text = "E&xit";
            // 
            // mView
            // 
            this.mView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTile,
            this.mDetails});
            this.mView.Name = "mView";
            this.mView.Size = new System.Drawing.Size(44, 20);
            this.mView.Text = "&View";
            // 
            // mTile
            // 
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(109, 22);
            this.mTile.Text = "&Tile";
            // 
            // mDetails
            // 
            this.mDetails.Name = "mDetails";
            this.mDetails.Size = new System.Drawing.Size(109, 22);
            this.mDetails.Text = "&Details";
            // 
            // mHelp
            // 
            this.mHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAbout});
            this.mHelp.Name = "mHelp";
            this.mHelp.Size = new System.Drawing.Size(44, 20);
            this.mHelp.Text = "&Help";
            // 
            // mAbout
            // 
            this.mAbout.Name = "mAbout";
            this.mAbout.Size = new System.Drawing.Size(116, 22);
            this.mAbout.Text = "&About...";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefresh,
            this.tsExport,
            this.tsRunTask});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1200, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // tsRefresh
            // 
            this.tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(50, 22);
            this.tsRefresh.Text = "Refresh";
            // 
            // tsExport
            // 
            this.tsExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(68, 22);
            this.tsExport.Text = "Export CSV";
            // 
            // tsRunTask
            // 
            this.tsRunTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsRunTask.Name = "tsRunTask";
            this.tsRunTask.Size = new System.Drawing.Size(58, 22);
            this.tsRunTask.Text = "Run Task";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 778);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 49);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tvCategories);
            this.splitMain.Panel1.Controls.Add(this.progressBar);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tableLayoutRight);
            this.splitMain.Panel2.Controls.Add(this.lvItems);
            this.splitMain.Size = new System.Drawing.Size(1200, 729);
            this.splitMain.SplitterDistance = 300;
            this.splitMain.TabIndex = 3;
            // 
            // tvCategories
            // 
            this.tvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCategories.Location = new System.Drawing.Point(0, 0);
            this.tvCategories.Name = "tvCategories";
            this.tvCategories.Size = new System.Drawing.Size(300, 705);
            this.tvCategories.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 705);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 24);
            this.progressBar.TabIndex = 1;
            // 
            // tableLayoutRight
            // 
            this.tableLayoutRight.ColumnCount = 2;
            this.tableLayoutRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutRight.Controls.Add(this.flowTop, 0, 0);
            this.tableLayoutRight.Controls.Add(this.dgvData, 0, 1);
            this.tableLayoutRight.Controls.Add(this.pbPreview, 1, 1);
            this.tableLayoutRight.Controls.Add(this.dtPicker, 0, 2);
            this.tableLayoutRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutRight.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutRight.Name = "tableLayoutRight";
            this.tableLayoutRight.RowCount = 3;
            this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutRight.Size = new System.Drawing.Size(896, 509);
            this.tableLayoutRight.TabIndex = 0;
            // 
            // flowTop
            // 
            this.flowTop.AutoSize = true;
            this.tableLayoutRight.SetColumnSpan(this.flowTop, 2);
            this.flowTop.Controls.Add(this.txtSearch);
            this.flowTop.Controls.Add(this.btnSearch);
            this.flowTop.Controls.Add(this.btnOpenDialog);
            this.flowTop.Controls.Add(this.btnChooseImage);
            this.flowTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTop.Location = new System.Drawing.Point(3, 3);
            this.flowTop.Name = "flowTop";
            this.flowTop.Padding = new System.Windows.Forms.Padding(6);
            this.flowTop.Size = new System.Drawing.Size(890, 38);
            this.flowTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(9, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(275, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Location = new System.Drawing.Point(356, 9);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDialog.TabIndex = 2;
            this.btnOpenDialog.Text = "Open Dialogs...";
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Location = new System.Drawing.Point(437, 9);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(75, 23);
            this.btnChooseImage.TabIndex = 3;
            this.btnChooseImage.Text = "Choose Image...";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 47);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(621, 419);
            this.dgvData.TabIndex = 1;
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(630, 47);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(263, 419);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // dtPicker
            // 
            this.tableLayoutRight.SetColumnSpan(this.dtPicker, 2);
            this.dtPicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker.Location = new System.Drawing.Point(3, 472);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(890, 20);
            this.dtPicker.TabIndex = 3;
            // 
            // lvItems
            // 
            this.lvItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvItems.HideSelection = false;
            this.lvItems.LargeImageList = this.imageList;
            this.lvItems.Location = new System.Drawing.Point(0, 509);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(896, 220);
            this.lvItems.SmallImageList = this.imageList;
            this.lvItems.TabIndex = 1;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(48, 48);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmPlayground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmPlayground";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playground - UI Components Demo";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tableLayoutRight.ResumeLayout(false);
            this.tableLayoutRight.PerformLayout();
            this.flowTop.ResumeLayout(false);
            this.flowTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}