using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLBanSach_GUI.Utilities
{
    /// <summary>
    /// Advanced tooltip helper for better UX
    /// </summary>
    public class TooltipHelper
    {
        private ToolTip toolTip;
        private Color backColor;
        private Color foreColor;

        public TooltipHelper(Color customBackColor = default(Color), Color customForeColor = default(Color))
        {
            toolTip = new ToolTip();
            
            backColor = customBackColor == default(Color) 
                ? Color.FromArgb(34, 65, 85) 
                : customBackColor;
            
            foreColor = customForeColor == default(Color) 
                ? Color.White 
                : customForeColor;

            // Configure tooltip appearance
            toolTip.BackColor = backColor;
            toolTip.ForeColor = foreColor;
            toolTip.IsBalloon = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
        }

        /// <summary>
        /// Add tooltip with title and description
        /// </summary>
        public void AddTooltip(Control control, string title, string description, string shortcut = "")
        {
            if (control == null) return;

            string tooltipText = string.Format("{0}\n{1}", title, description);
            if (!string.IsNullOrEmpty(shortcut))
                tooltipText += string.Format("\n\n【{0}】", shortcut);

            toolTip.SetToolTip(control, tooltipText);
        }

        /// <summary>
        /// Add simple tooltip
        /// </summary>
        public void AddSimpleTooltip(Control control, string text)
        {
            if (control == null) return;
            toolTip.SetToolTip(control, text);
        }

        /// <summary>
        /// Remove tooltip from control
        /// </summary>
        public void RemoveTooltip(Control control)
        {
            if (control == null) return;
            toolTip.SetToolTip(control, "");
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            if (toolTip != null)
            {
                toolTip.Dispose();
                toolTip = null;
            }
        }
    }
}