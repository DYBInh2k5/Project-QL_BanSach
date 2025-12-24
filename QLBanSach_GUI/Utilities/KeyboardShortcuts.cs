using System;
using System.Collections.Generic;

namespace QLBanSach_GUI.Utilities
{
    /// <summary>
    /// Keyboard shortcuts reference
    /// </summary>
    public static class KeyboardShortcuts
    {
        public static readonly Dictionary<string, string> Shortcuts = new Dictionary<string, string>()
        {
            // File Operations
            { "F5", "Làm mới dữ liệu (Refresh)" },
            { "Ctrl+S", "Lưu thay đổi (Save)" },
            { "Ctrl+N", "Tạo mới (New)" },
            { "Ctrl+O", "Mở (Open)" },
            { "Ctrl+P", "In tài liệu (Print)" },
            { "Ctrl+E", "Xuất Excel (Export)" },
            { "Ctrl+Q", "Thoát ứng dụng (Quit)" },

            // Edit Operations
            { "Ctrl+Z", "Hoàn tác (Undo)" },
            { "Ctrl+Y", "Làm lại (Redo)" },
            { "Ctrl+X", "Cắt (Cut)" },
            { "Ctrl+C", "Sao chép (Copy)" },
            { "Ctrl+V", "Dán (Paste)" },
            { "Ctrl+A", "Chọn tất cả (Select All)" },
            { "Ctrl+F", "Tìm kiếm (Find)" },
            { "Ctrl+H", "Tìm và thay thế (Find & Replace)" },

            // Navigation
            { "Ctrl+Tab", "Chuyển tab tiếp theo (Next Tab)" },
            { "Ctrl+Shift+Tab", "Chuyển tab trước (Previous Tab)" },
            { "Alt+Home", "Về trang chủ (Home)" },
            { "Alt+1", "Quản lý Hóa đơn" },
            { "Alt+2", "Quản lý Khách hàng" },
            { "Alt+3", "Quản lý Sách" },
            { "Alt+4", "Thống kê" },

            // Help & Settings
            { "F1", "Trợ giúp (Help)" },
            { "Ctrl+Shift+S", "Cài đặt (Settings)" },
            { "Ctrl+Shift+?", "Về ứng dụng (About)" },

            // Window Operations
            { "Alt+Tab", "Chuyển cửa sổ (Switch Window)" },
            { "Alt+F4", "Đóng ứng dụng (Close App)" },
            { "F11", "Toàn màn hình (Full Screen)" },
            { "Escape", "Hủy / Đóng (Cancel / Close)" }
        };

        public static string GetShortcutDescription(string shortcut)
        {
            return Shortcuts.TryGetValue(shortcut, out var description) ? description : "Không tìm thấy";
        }

        public static string GetAllShortcuts()
        {
            string result = "=== KEYBOARD SHORTCUTS ===\n\n";
            foreach (var kvp in Shortcuts)
            {
                result += $"{kvp.Key,-20} : {kvp.Value}\n";
            }
            return result;
        }
    }
}