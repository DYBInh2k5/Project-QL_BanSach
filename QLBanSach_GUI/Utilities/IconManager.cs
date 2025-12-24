using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLBanSach_GUI.Utilities
{
    /// <summary>
    /// Manages application icons and tooltips
    /// </summary>
    public static class IconManager
    {
        #region Icon & Tooltip Definitions

        /// <summary>
        /// Navigation Button Configuration
        /// </summary>
        public static readonly Dictionary<string, IconConfig> NavButtonConfig = new Dictionary<string, IconConfig>()
        {
            { "btnHome", new IconConfig { Emoji = "🏠", Tooltip = "Trang chủ - Hiển thị bảng điều khiển chính" } },
            { "btnInvoice", new IconConfig { Emoji = "📋", Tooltip = "Quản lý Hóa đơn - Xem, tạo, chỉnh sửa hóa đơn" } },
            { "btnCustomer", new IconConfig { Emoji = "👥", Tooltip = "Quản lý Khách hàng - Quản lý thông tin khách hàng" } },
            { "btnBook", new IconConfig { Emoji = "📚", Tooltip = "Quản lý Sách - Quản lý kho sách, tồn kho" } },
            { "btnThongKe", new IconConfig { Emoji = "📊", Tooltip = "Thống kê - Xem báo cáo doanh thu, thống kê bán hàng" } },
            { "btnAccount", new IconConfig { Emoji = "👤", Tooltip = "Quản lý Tài khoản - Quản lý tài khoản người dùng" } },
            { "btnChiTietNhanVien", new IconConfig { Emoji = "💼", Tooltip = "Nhân Sự - Quản lý nhân viên, lương, chức vụ" } },
            { "btnTaiKhoan", new IconConfig { Emoji = "🔐", Tooltip = "Tài Khoản - Quản lý tài khoản cá nhân" } },
            { "btnLogout", new IconConfig { Emoji = "🚪", Tooltip = "Đăng xuất - Thoát tài khoản hiện tại" } },
            { "btnClose", new IconConfig { Emoji = "❌", Tooltip = "Thoát - Đóng ứng dụng" } },
            { "btnNguyenVatLieu", new IconConfig { Emoji = "🏷️", Tooltip = "Thể Loại - Quản lý thể loại sách" } },
            { "btnNhapKho", new IconConfig { Emoji = "📦", Tooltip = "Nhập Kho - Quản lý nhập hàng, tồn kho" } },
            { "guna2Button1", new IconConfig { Emoji = "🛒", Tooltip = "POS - Hệ thống bán hàng tại quầy" } },
            { "guna2Button2", new IconConfig { Emoji = "💳", Tooltip = "POS - Điểm bán hàng" } },
            { "btnDoiTra", new IconConfig { Emoji = "🔄", Tooltip = "Đổi Trả - Quản lý đổi trả, hoàn tiền" } }
        };

        /// <summary>
        /// ToolStrip Button Configuration
        /// </summary>
        public static readonly Dictionary<string, ToolButtonConfig> ToolButtonConfigMap = new Dictionary<string, ToolButtonConfig>()
        {
            { "btnToolRefresh", new ToolButtonConfig { Emoji = "🔄", Tooltip = "Làm mới dữ liệu hiện tại", KeyShortcut = "F5" } },
            { "btnToolSave", new ToolButtonConfig { Emoji = "💾", Tooltip = "Lưu thay đổi", KeyShortcut = "Ctrl+S" } },
            { "btnToolPrint", new ToolButtonConfig { Emoji = "🖨️", Tooltip = "In tài liệu, hóa đơn", KeyShortcut = "Ctrl+P" } },
            { "btnToolExport", new ToolButtonConfig { Emoji = "📤", Tooltip = "Xuất dữ liệu ra Excel", KeyShortcut = "Ctrl+E" } },
            { "btnToolSearch", new ToolButtonConfig { Emoji = "🔍", Tooltip = "Tìm kiếm thông tin", KeyShortcut = "Ctrl+F" } },
            { "btnToolSettings", new ToolButtonConfig { Emoji = "⚙️", Tooltip = "Cài đặt ứng dụng", KeyShortcut = "Ctrl+Shift+S" } },
            { "btnToolHelp", new ToolButtonConfig { Emoji = "❓", Tooltip = "Xem trợ giúp và hướng dẫn", KeyShortcut = "F1" } }
        };

        /// <summary>
        /// Dialog Button Configuration
        /// </summary>
        public static readonly Dictionary<string, DialogButtonConfig> DialogButtonConfigMap = new Dictionary<string, DialogButtonConfig>()
        {
            { "btnOK", new DialogButtonConfig { Emoji = "✅", Color = "Green" } },
            { "btnCancel", new DialogButtonConfig { Emoji = "❌", Color = "Red" } },
            { "btnReset", new DialogButtonConfig { Emoji = "🔄", Color = "Blue" } },
            { "btnApply", new DialogButtonConfig { Emoji = "💾", Color = "Green" } },
            { "btnClose", new DialogButtonConfig { Emoji = "✕", Color = "Red" } }
        };

        #endregion

        #region Configuration Classes

        public class IconConfig
        {
            public string Emoji { get; set; }
            public string Tooltip { get; set; }
        }

        public class ToolButtonConfig
        {
            public string Emoji { get; set; }
            public string Tooltip { get; set; }
            public string KeyShortcut { get; set; }
        }

        public class DialogButtonConfig
        {
            public string Emoji { get; set; }
            public string Color { get; set; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialize navigation button with icon and tooltip
        /// </summary>
        public static void SetupNavButton(Button btn, string buttonName)
        {
            if (btn == null) return;

            IconConfig config;
            if (NavButtonConfig.TryGetValue(buttonName, out config))
            {
                btn.Text = string.Format("{0} {1}", config.Emoji, btn.Text);
                btn.AutoSize = true;
                
                ToolTip tooltip = new ToolTip();
                tooltip.SetToolTip(btn, config.Tooltip);
                tooltip.AutoPopDelay = 5000;
                tooltip.InitialDelay = 500;
            }
        }

        /// <summary>
        /// Initialize toolbar button with icon and tooltip
        /// </summary>
        public static void SetupToolButton(ToolStripButton btn, string buttonName)
        {
            if (btn == null) return;

            ToolButtonConfig config;
            if (ToolButtonConfigMap.TryGetValue(buttonName, out config))
            {
                btn.Text = string.Format("{0} {1}", config.Emoji, btn.Text);
                btn.ToolTipText = string.Format("{0} ({1})", config.Tooltip, config.KeyShortcut);
                btn.AutoSize = true;
            }
        }

        /// <summary>
        /// Initialize dialog button with icon
        /// </summary>
        public static void SetupDialogButton(Button btn, string buttonName)
        {
            if (btn == null) return;

            DialogButtonConfig config;
            if (DialogButtonConfigMap.TryGetValue(buttonName, out config))
            {
                btn.Text = string.Format("{0} {1}", config.Emoji, btn.Text);
                btn.AutoSize = true;
            }
        }

        /// <summary>
        /// Get button configuration
        /// </summary>
        public static IconConfig GetNavButtonConfig(string buttonName)
        {
            IconConfig config;
            if (NavButtonConfig.TryGetValue(buttonName, out config))
            {
                return config;
            }
            return null;
        }

        /// <summary>
        /// Create tooltip with multi-line text
        /// </summary>
        public static ToolTip CreateAdvancedTooltip(string title, string description, string shortcut = "")
        {
            ToolTip tooltip = new ToolTip();
            string text = string.Format("{0}\n{1}", title, description);
            if (!string.IsNullOrEmpty(shortcut))
                text += string.Format("\n\n{0}", shortcut);
            
            tooltip.IsBalloon = true;
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 500;
            tooltip.ReshowDelay = 100;
            return tooltip;
        }

        #endregion
    }
}