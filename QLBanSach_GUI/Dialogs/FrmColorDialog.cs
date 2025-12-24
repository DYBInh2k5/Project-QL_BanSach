using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSach_GUI.Dialogs
{
    /// <summary>
    /// Custom Color Picker Dialog
    /// </summary>
    public partial class FrmColorDialog : Form
    {
        private Color selectedColor = Color.White;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        public FrmColorDialog()
        {
            InitializeComponent();
            InitializeColorPalette();
        }

        public FrmColorDialog(Color initialColor)
            : this()
        {
            selectedColor = initialColor;
            
            if (this.pnlPreview != null)
                this.pnlPreview.BackColor = selectedColor;
            
            if (this.lblColorValue != null)
                this.lblColorValue.Text = ColorToHex(selectedColor);
        }

        private void InitializeColorPalette()
        {
            try
            {
                // Define standard colors
                Color[] colors = new Color[]
                {
                    Color.Red,
                    Color.Green,
                    Color.Blue,
                    Color.Yellow,
                    Color.Cyan,
                    Color.Magenta,
                    Color.Black,
                    Color.White,
                    Color.Gray,
                    Color.LightBlue,
                    Color.LightGreen,
                    Color.LightCoral,
                    Color.Orange,
                    Color.Purple,
                    Color.Brown,
                    Color.Pink
                };

                if (this.flpColorPalette != null)
                {
                    this.flpColorPalette.Controls.Clear();

                    foreach (Color color in colors)
                    {
                        Panel p = new Panel();
                        p.Width = 50;
                        p.Height = 50;
                        p.BackColor = color;
                        p.BorderStyle = BorderStyle.FixedSingle;
                        p.Margin = new Padding(5);
                        p.Cursor = Cursors.Hand;
                        p.Tag = color;

                        p.Click += (s, e) =>
                        {
                            selectedColor = (Color)p.Tag;
                            if (this.pnlPreview != null)
                                this.pnlPreview.BackColor = selectedColor;
                            if (this.lblColorValue != null)
                                this.lblColorValue.Text = ColorToHex(selectedColor);
                        };

                        this.flpColorPalette.Controls.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải màu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ColorToHex(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
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