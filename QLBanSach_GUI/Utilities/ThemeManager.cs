using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLBanSach_GUI.Utilities
{
    /// <summary>
    /// Manages application theme, colors, and styling
    /// </summary>
    public static class ThemeManager
    {
        public enum ThemeType
        {
            Light,
            Dark,
            Blue,
            Green
        }

        private static ThemeType currentTheme = ThemeType.Light;

        public static Color PrimaryColor { get; set; } = Color.FromArgb(59, 130, 246);
        public static Color SecondaryColor { get; set; } = Color.FromArgb(107, 114, 128);
        public static Color SuccessColor { get; set; } = Color.FromArgb(34, 197, 94);
        public static Color DangerColor { get; set; } = Color.FromArgb(239, 68, 68);
        public static Color WarningColor { get; set; } = Color.FromArgb(251, 146, 60);
        public static Color InfoColor { get; set; } = Color.FromArgb(59, 130, 246);

        public static void SetTheme(ThemeType theme)
        {
            currentTheme = theme;

            switch (theme)
            {
                case ThemeType.Dark:
                    ApplyDarkTheme();
                    break;
                case ThemeType.Blue:
                    ApplyBlueTheme();
                    break;
                case ThemeType.Green:
                    ApplyGreenTheme();
                    break;
                default:
                    ApplyLightTheme();
                    break;
            }
        }

        private static void ApplyLightTheme()
        {
            PrimaryColor = Color.FromArgb(59, 130, 246);
            SecondaryColor = Color.FromArgb(107, 114, 128);
            SuccessColor = Color.FromArgb(34, 197, 94);
            DangerColor = Color.FromArgb(239, 68, 68);
            WarningColor = Color.FromArgb(251, 146, 60);
            InfoColor = Color.FromArgb(59, 130, 246);
        }

        private static void ApplyDarkTheme()
        {
            PrimaryColor = Color.FromArgb(96, 165, 250);
            SecondaryColor = Color.FromArgb(156, 163, 175);
            SuccessColor = Color.FromArgb(74, 222, 128);
            DangerColor = Color.FromArgb(248, 113, 113);
            WarningColor = Color.FromArgb(253, 176, 90);
            InfoColor = Color.FromArgb(96, 165, 250);
        }

        private static void ApplyBlueTheme()
        {
            PrimaryColor = Color.FromArgb(29, 78, 216);
            SecondaryColor = Color.FromArgb(75, 85, 99);
            SuccessColor = Color.FromArgb(16, 185, 129);
            DangerColor = Color.FromArgb(245, 34, 34);
            WarningColor = Color.FromArgb(251, 140, 0);
            InfoColor = Color.FromArgb(59, 130, 246);
        }

        private static void ApplyGreenTheme()
        {
            PrimaryColor = Color.FromArgb(34, 197, 94);
            SecondaryColor = Color.FromArgb(100, 116, 139);
            SuccessColor = Color.FromArgb(34, 197, 94);
            DangerColor = Color.FromArgb(239, 68, 68);
            WarningColor = Color.FromArgb(251, 146, 60);
            InfoColor = Color.FromArgb(59, 130, 246);
        }

        /// <summary>
        /// Apply theme to form
        /// </summary>
        public static void ApplyThemeToForm(Form form)
        {
            if (form == null) return;

            form.BackColor = Color.White;
            form.ForeColor = Color.Black;

            ApplyThemeToControlRecursive(form);
        }

        private static void ApplyThemeToControlRecursive(Control parent)
        {
            if (parent == null) return;

            foreach (Control control in parent.Controls)
            {
                if (control is Button)
                {
                    ApplyButtonTheme((Button)control);
                }
                else if (control is Label)
                {
                    ApplyLabelTheme((Label)control);
                }
                else if (control is TextBox)
                {
                    ApplyTextBoxTheme((TextBox)control);
                }
                else if (control is DataGridView)
                {
                    ApplyDataGridViewTheme((DataGridView)control);
                }

                if (control.HasChildren)
                {
                    ApplyThemeToControlRecursive(control);
                }
            }
        }

        private static void ApplyButtonTheme(Button btn)
        {
            if (btn == null) return;

            btn.BackColor = PrimaryColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
        }

        private static void ApplyLabelTheme(Label lbl)
        {
            if (lbl == null) return;
            lbl.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private static void ApplyTextBoxTheme(TextBox txt)
        {
            if (txt == null) return;

            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void ApplyDataGridViewTheme(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(229, 231, 235);
            
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            defaultStyle.BackColor = Color.White;
            defaultStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle = defaultStyle;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = PrimaryColor;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
        }
    }
}