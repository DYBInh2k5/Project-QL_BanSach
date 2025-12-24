namespace QLBanSach_GUI.Dialogs
{
    partial class FrmColorDialog
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
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.lblColorValue = new System.Windows.Forms.Label();
            this.flpColorPalette = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // pnlPreview
            this.pnlPreview.BackColor = System.Drawing.Color.White;
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreview.Location = new System.Drawing.Point(12, 40);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(460, 80);
            this.pnlPreview.TabIndex = 0;

            // lblColorValue
            this.lblColorValue.AutoSize = true;
            this.lblColorValue.Location = new System.Drawing.Point(12, 130);
            this.lblColorValue.Name = "lblColorValue";
            this.lblColorValue.Size = new System.Drawing.Size(50, 13);
            this.lblColorValue.TabIndex = 1;
            this.lblColorValue.Text = "#FFFFFF";

            // flpColorPalette
            this.flpColorPalette.AutoScroll = true;
            this.flpColorPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpColorPalette.Location = new System.Drawing.Point(12, 155);
            this.flpColorPalette.Name = "flpColorPalette";
            this.flpColorPalette.Size = new System.Drawing.Size(460, 200);
            this.flpColorPalette.TabIndex = 2;

            // btnOK
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(317, 365);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(397, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 20);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Chọn Màu Sắc";

            // FrmColorDialog
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 409);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.flpColorPalette);
            this.Controls.Add(this.lblColorValue);
            this.Controls.Add(this.pnlPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmColorDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Màu Sắc";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label lblColorValue;
        private System.Windows.Forms.FlowLayoutPanel flpColorPalette;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
    }
}