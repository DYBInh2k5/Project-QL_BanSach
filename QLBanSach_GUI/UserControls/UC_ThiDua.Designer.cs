namespace QLBanSach_GUI.UserControls
{
    partial class UC_ThiDua
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpLeaderboard;
        private System.Windows.Forms.DataGridView dgvLeaderboard;
        private System.Windows.Forms.FlowLayoutPanel flowHeader;
        private System.Windows.Forms.Label lblTopEmployee;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportPdf; // NEW

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpLeaderboard = new System.Windows.Forms.GroupBox();
            this.dgvLeaderboard = new System.Windows.Forms.DataGridView();
            this.flowHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.lblTopEmployee = new System.Windows.Forms.Label();
            this.grpLeaderboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).BeginInit();
            this.flowHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLeaderboard
            // 
            this.grpLeaderboard.Controls.Add(this.dgvLeaderboard);
            this.grpLeaderboard.Controls.Add(this.flowHeader);
            this.grpLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLeaderboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpLeaderboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.grpLeaderboard.Name = "grpLeaderboard";
            this.grpLeaderboard.Padding = new System.Windows.Forms.Padding(10);
            this.grpLeaderboard.Size = new System.Drawing.Size(800, 450);
            this.grpLeaderboard.TabIndex = 0;
            this.grpLeaderboard.TabStop = false;
            this.grpLeaderboard.Text = "Thi đua: Nhân viên bán nhiều sách";
            // 
            // dgvLeaderboard
            // 
            this.dgvLeaderboard.AllowUserToAddRows = false;
            this.dgvLeaderboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeaderboard.BackgroundColor = System.Drawing.Color.White;
            this.dgvLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeaderboard.Location = new System.Drawing.Point(10, 66);
            this.dgvLeaderboard.Name = "dgvLeaderboard";
            this.dgvLeaderboard.ReadOnly = true;
            this.dgvLeaderboard.RowHeadersVisible = false;
            this.dgvLeaderboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeaderboard.Size = new System.Drawing.Size(780, 374);
            this.dgvLeaderboard.TabIndex = 0;
            // 
            // flowHeader
            // 
            this.flowHeader.Controls.Add(this.btnExportPdf);
            this.flowHeader.Controls.Add(this.btnRefresh);
            this.flowHeader.Controls.Add(this.cboPeriod);
            this.flowHeader.Controls.Add(this.lblTopEmployee);
            this.flowHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowHeader.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowHeader.Location = new System.Drawing.Point(10, 26);
            this.flowHeader.Name = "flowHeader";
            this.flowHeader.Size = new System.Drawing.Size(780, 40);
            this.flowHeader.TabIndex = 1;
            this.flowHeader.WrapContents = false;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Location = new System.Drawing.Point(677, 3);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(100, 23);
            this.btnExportPdf.TabIndex = 0;
            this.btnExportPdf.Text = "Xuất PDF";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(571, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            // 
            // cboPeriod
            // 
            this.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriod.Items.AddRange(new object[] {
            "Tất cả",
            "Tháng này",
            "Năm nay"});
            this.cboPeriod.Location = new System.Drawing.Point(425, 3);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(140, 23);
            this.cboPeriod.TabIndex = 2;
            // 
            // lblTopEmployee
            // 
            this.lblTopEmployee.AutoSize = true;
            this.lblTopEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTopEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTopEmployee.Location = new System.Drawing.Point(265, 0);
            this.lblTopEmployee.Name = "lblTopEmployee";
            this.lblTopEmployee.Size = new System.Drawing.Size(154, 19);
            this.lblTopEmployee.TabIndex = 3;
            this.lblTopEmployee.Text = "Top: (chưa có dữ liệu)";
            // 
            // UC_ThiDua
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpLeaderboard);
            this.Name = "UC_ThiDua";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.UC_ThiDua_Load);
            this.grpLeaderboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).EndInit();
            this.flowHeader.ResumeLayout(false);
            this.flowHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}