namespace QLBanSach_GUI.Dialogs
{
    partial class FrmProfile
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnChangeAvatar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(20, 20);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(120, 120);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(160, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(300, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Họ tên:";
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(160, 45);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(300, 20);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Vai trò:";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(160, 70);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(300, 20);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Tài khoản:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(20, 202);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(440, 20);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(20, 222);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(440, 20);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Điện thoại:";
            // 
            // lblCCCD
            // 
            this.lblCCCD.Location = new System.Drawing.Point(20, 242);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(440, 20);
            this.lblCCCD.TabIndex = 6;
            this.lblCCCD.Text = "CCCD:";
            // 
            // lblDOB
            // 
            this.lblDOB.Location = new System.Drawing.Point(20, 262);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(440, 20);
            this.lblDOB.TabIndex = 7;
            this.lblDOB.Text = "Ngày sinh:";
            // 
            // lblCreated
            // 
            this.lblCreated.Location = new System.Drawing.Point(20, 282);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(440, 20);
            this.lblCreated.TabIndex = 8;
            this.lblCreated.Text = "Ngày tạo:";
            this.lblCreated.Click += new System.EventHandler(this.lblCreated_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 302);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(440, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // btnChangeAvatar
            // 
            this.btnChangeAvatar.Location = new System.Drawing.Point(20, 145);
            this.btnChangeAvatar.Name = "btnChangeAvatar";
            this.btnChangeAvatar.Size = new System.Drawing.Size(120, 23);
            this.btnChangeAvatar.TabIndex = 10;
            this.btnChangeAvatar.Text = "Đổi ảnh...";
            this.btnChangeAvatar.UseVisualStyleBackColor = true;
            this.btnChangeAvatar.Click += new System.EventHandler(this.btnChangeAvatar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(380, 325);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmProfile
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 371);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChangeAvatar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picAvatar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hồ sơ người dùng";
            this.Load += new System.EventHandler(this.FrmProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnChangeAvatar;
        private System.Windows.Forms.Button btnClose;
    }
}