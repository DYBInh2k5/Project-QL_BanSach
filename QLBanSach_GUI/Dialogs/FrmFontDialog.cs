using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanSach_GUI.Utilities;

namespace QLBanSach_GUI.Dialogs
{
    /// <summary>
    /// Custom Font Picker Dialog
    /// </summary>
    public partial class FrmFontDialog : Form
    {
        private Font selectedFont = SystemFonts.DefaultFont;

        public Font SelectedFont
        {
            get { return selectedFont; }
            set { selectedFont = value; }
        }

        public FrmFontDialog()
        {
            InitializeComponent();
            InitializeFonts();
        }

        public FrmFontDialog(Font initialFont)
            : this()
        {
            if (initialFont != null)
            {
                selectedFont = initialFont;
                UpdateFontSelection();
            }
        }

        private void InitializeFonts()
        {
            try
            {
                // Load available fonts
                foreach (FontFamily fontFamily in FontFamily.Families)
                {
                    if (this.cbFont != null)
                        this.cbFont.Items.Add(fontFamily.Name);
                }

                // Load font sizes
                int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
                foreach (int size in sizes)
                {
                    if (this.cbSize != null)
                        this.cbSize.Items.Add(size);
                }

                if (this.cbFont != null && this.cbFont.Items.Count > 0)
                    this.cbFont.SelectedIndex = 0;
                
                if (this.cbSize != null && this.cbSize.Items.Count > 3)
                    this.cbSize.SelectedIndex = 3; // Default to 11
            }
            catch (Exception ex)
            {
                ValidationManager.ShowError("Font Dialog", 
                    "Lỗi khi tải font: " + ex.Message);
            }
        }

        private void UpdateFontSelection()
        {
            try
            {
                if (this.cbFont != null)
                    this.cbFont.Text = selectedFont.Name;
                
                if (this.cbSize != null)
                    this.cbSize.Text = selectedFont.Size.ToString();
                
                if (this.chkBold != null)
                    this.chkBold.Checked = selectedFont.Bold;
                
                if (this.chkItalic != null)
                    this.chkItalic.Checked = selectedFont.Italic;
                
                if (this.chkUnderline != null)
                    this.chkUnderline.Checked = selectedFont.Underline;

                UpdatePreview();
            }
            catch (Exception ex)
            {
                ValidationManager.ShowError("Font Dialog", 
                    "Lỗi cập nhật font: " + ex.Message);
            }
        }

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void chkUnderline_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            try
            {
                if (this.cbFont == null || this.cbSize == null)
                    return;

                string fontName = this.cbFont.Text;
                string sizeText = this.cbSize.Text;

                if (string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(sizeText))
                    return;

                float size;
                if (!float.TryParse(sizeText, out size))
                {
                    ValidationManager.ShowError("Kích cỡ Font", 
                        ValidationManager.GetMessage("Decimal"));
                    return;
                }

                FontStyle style = FontStyle.Regular;

                if (this.chkBold != null && this.chkBold.Checked)
                    style = style | FontStyle.Bold;
                
                if (this.chkItalic != null && this.chkItalic.Checked)
                    style = style | FontStyle.Italic;
                
                if (this.chkUnderline != null && this.chkUnderline.Checked)
                    style = style | FontStyle.Underline;

                selectedFont = new Font(fontName, size, style);
                
                if (this.lblPreview != null)
                {
                    this.lblPreview.Font = selectedFont;
                    this.lblPreview.Text = "Xem trước: Quản Lý Bán Sách";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Font update error: " + ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate before closing
            string fontError = null;
            string sizeError = null;

            if (!ValidationManager.ValidateRequired(this.cbFont?.Text, out fontError))
            {
                ValidationManager.ShowError("Font", fontError);
                return;
            }

            if (!ValidationManager.ValidateRequired(this.cbSize?.Text, out sizeError))
            {
                ValidationManager.ShowError("Kích cỡ", sizeError);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}