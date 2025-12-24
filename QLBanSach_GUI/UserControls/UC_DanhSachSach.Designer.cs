namespace QLBanSach_GUI.UserControls
{
    partial class UC_DanhSachSach
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
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnChangeCover = new System.Windows.Forms.Button();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.pbCover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(12, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(420, 20);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(438, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(524, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Xuất CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnChangeCover
            // 
            this.btnChangeCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeCover.Location = new System.Drawing.Point(630, 10);
            this.btnChangeCover.Name = "btnChangeCover";
            this.btnChangeCover.Size = new System.Drawing.Size(110, 23);
            this.btnChangeCover.TabIndex = 3;
            this.btnChangeCover.Text = "Đổi ảnh bìa...";
            this.btnChangeCover.UseVisualStyleBackColor = true;
            this.btnChangeCover.Click += new System.EventHandler(this.btnChangeCover_Click);
            // 
            // dgvSach
            // 
            this.dgvSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(12, 44);
            this.dgvSach.MultiSelect = false;
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersVisible = false;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(570, 344);
            this.dgvSach.TabIndex = 4;
            // 
            // pbCover
            // 
            this.pbCover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCover.Location = new System.Drawing.Point(590, 44);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(150, 344);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCover.TabIndex = 5;
            this.pbCover.TabStop = false;
            // 
            // UC_DanhSachSach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.dgvSach);
            this.Controls.Add(this.btnChangeCover);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "UC_DanhSachSach";
            this.Size = new System.Drawing.Size(752, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnChangeCover;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.PictureBox pbCover;
    }
}
