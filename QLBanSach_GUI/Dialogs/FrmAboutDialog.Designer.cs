namespace QLBanSach_GUI.Dialogs
{
    partial class FrmAboutDialog
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

        private void InitializeComponent()
        {
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.rtbAboutText = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppName.Location = new System.Drawing.Point(120, 12);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(262, 25);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "Hệ Thống Quản Lý Bán Sách";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(120, 45);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(85, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Phiên bản: 1.0.0";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(120, 65);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(153, 13);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Công ty: Thư viên Võ Duy Bình";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(120, 85);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(231, 13);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Bản quyền: © 2025 - Tất cả các quyền bảo lưu";
            // 
            // rtbAboutText
            // 
            this.rtbAboutText.Location = new System.Drawing.Point(12, 125);
            this.rtbAboutText.Name = "rtbAboutText";
            this.rtbAboutText.ReadOnly = true;
            this.rtbAboutText.Size = new System.Drawing.Size(460, 250);
            this.rtbAboutText.TabIndex = 5;
            this.rtbAboutText.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Blue;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(397, 382);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAboutDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(484, 422);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbAboutText);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Về Ứng Dụng";
            this.Load += new System.EventHandler(this.FrmAboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.RichTextBox rtbAboutText;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}