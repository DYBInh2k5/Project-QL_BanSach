namespace QLBanSach_GUI.Dialogs
{
    partial class FrmFontDialog
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
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkUnderline = new System.Windows.Forms.CheckBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFont = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.pnlPreview.SuspendLayout();
            this.SuspendLayout();

            // cbFont
            this.cbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Location = new System.Drawing.Point(80, 12);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(200, 21);
            this.cbFont.TabIndex = 0;
            this.cbFont.SelectedIndexChanged += new System.EventHandler(this.cbFont_SelectedIndexChanged);

            // cbSize
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Location = new System.Drawing.Point(80, 45);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(100, 21);
            this.cbSize.TabIndex = 1;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);

            // chkBold
            this.chkBold.AutoSize = true;
            this.chkBold.Location = new System.Drawing.Point(80, 75);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(47, 17);
            this.chkBold.TabIndex = 2;
            this.chkBold.Text = "Bold";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);

            // chkItalic
            this.chkItalic.AutoSize = true;
            this.chkItalic.Location = new System.Drawing.Point(150, 75);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(48, 17);
            this.chkItalic.TabIndex = 3;
            this.chkItalic.Text = "Italic";
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);

            // chkUnderline
            this.chkUnderline.AutoSize = true;
            this.chkUnderline.Location = new System.Drawing.Point(220, 75);
            this.chkUnderline.Name = "chkUnderline";
            this.chkUnderline.Size = new System.Drawing.Size(75, 17);
            this.chkUnderline.TabIndex = 4;
            this.chkUnderline.Text = "Underline";
            this.chkUnderline.UseVisualStyleBackColor = true;
            this.chkUnderline.CheckedChanged += new System.EventHandler(this.chkUnderline_CheckedChanged);

            // pnlPreview
            this.pnlPreview.BackColor = System.Drawing.Color.White;
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreview.Controls.Add(this.lblPreview);
            this.pnlPreview.Location = new System.Drawing.Point(12, 105);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(350, 120);
            this.pnlPreview.TabIndex = 5;

            // lblPreview
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(10, 10);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(60, 13);
            this.lblPreview.TabIndex = 6;
            this.lblPreview.Text = "Xem trước";

            // btnOK
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(215, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(287, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // lblFont
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(12, 15);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(40, 13);
            this.lblFont.TabIndex = 9;
            this.lblFont.Text = "Font:";

            // lblSize
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(12, 45);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(37, 13);
            this.lblSize.TabIndex = 10;
            this.lblSize.Text = "Kích cỡ:";

            // lblStyle
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(12, 75);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(37, 13);
            this.lblStyle.TabIndex = 11;
            this.lblStyle.Text = "Kiểu:";

            // FrmFontDialog
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(374, 279);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.chkUnderline);
            this.Controls.Add(this.chkItalic);
            this.Controls.Add(this.chkBold);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.cbFont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFontDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Font";
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cbFont;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkUnderline;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Panel pnlPreview;
    }
}