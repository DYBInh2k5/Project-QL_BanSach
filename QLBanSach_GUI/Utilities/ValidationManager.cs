using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLBanSach_GUI.Utilities
{
    /// <summary>
    /// Manages data validation with user-friendly messages
    /// </summary>
    public static class ValidationManager
    {
        #region Validation Rules

        public enum ValidationRule
        {
            Required,
            Email,
            Phone,
            Numeric,
            Decimal,
            MinLength,
            MaxLength,
            RangeLength,
            Custom
        }

        #endregion

        #region Error Messages Dictionary

        private static readonly Dictionary<string, string> ValidationMessages = new Dictionary<string, string>()
        {
            // Vietnamese error messages
            { "Required", "⚠️ Trường này không được để trống" },
            { "Email", "⚠️ Địa chỉ email không hợp lệ. Vui lòng nhập theo định dạng: example@domain.com" },
            { "Phone", "⚠️ Số điện thoại không hợp lệ. Vui lòng nhập 10-11 chữ số" },
            { "Numeric", "⚠️ Vui lòng nhập số nguyên dương" },
            { "Decimal", "⚠️ Vui lòng nhập số thập phân hợp lệ" },
            { "MinLength", "⚠️ Vui lòng nhập ít nhất {0} ký tự" },
            { "MaxLength", "⚠️ Không được nhập quá {0} ký tự" },
            { "RangeLength", "⚠️ Vui lòng nhập từ {0} đến {1} ký tự" },
            { "RangeValue", "⚠️ Giá trị phải nằm trong khoảng {0} đến {1}" },
            { "PasswordMatch", "⚠️ Mật khẩu xác nhận không khớp" },
            { "FileExists", "⚠️ Tập tin không tồn tại. Vui lòng chọn tập tin hợp lệ" },
            { "InvalidDate", "⚠️ Ngày tháng không hợp lệ. Vui lòng nhập theo định dạng: dd/MM/yyyy" }
        };

        #endregion

        #region Validation Methods

        /// <summary>
        /// Validate required field
        /// </summary>
        public static bool ValidateRequired(string value, out string errorMessage)
        {
            errorMessage = null;
            
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMessage = GetMessage("Required");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate email format
        /// </summary>
        public static bool ValidateEmail(string email, out string errorMessage)
        {
            errorMessage = null;

            if (!ValidateRequired(email, out errorMessage))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                errorMessage = GetMessage("Email");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate phone number
        /// </summary>
        public static bool ValidatePhone(string phone, out string errorMessage)
        {
            errorMessage = null;

            if (!ValidateRequired(phone, out errorMessage))
                return false;

            // Remove non-digit characters
            string digitsOnly = Regex.Replace(phone, @"\D", "");
            
            if (digitsOnly.Length < 10 || digitsOnly.Length > 11)
            {
                errorMessage = GetMessage("Phone");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate integer number
        /// </summary>
        public static bool ValidateNumeric(string value, out string errorMessage, out int result)
        {
            errorMessage = null;
            result = 0;

            if (!ValidateRequired(value, out errorMessage))
                return false;

            if (!int.TryParse(value, out result))
            {
                errorMessage = GetMessage("Numeric");
                return false;
            }

            if (result < 0)
            {
                errorMessage = GetMessage("Numeric");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate decimal number
        /// </summary>
        public static bool ValidateDecimal(string value, out string errorMessage, out decimal result)
        {
            errorMessage = null;
            result = 0m;

            if (!ValidateRequired(value, out errorMessage))
                return false;

            if (!decimal.TryParse(value, out result))
            {
                errorMessage = GetMessage("Decimal");
                return false;
            }

            if (result < 0)
            {
                errorMessage = GetMessage("Decimal");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate minimum length
        /// </summary>
        public static bool ValidateMinLength(string value, int minLength, out string errorMessage)
        {
            errorMessage = null;

            if (!ValidateRequired(value, out errorMessage))
                return false;

            if (value.Length < minLength)
            {
                errorMessage = string.Format(GetMessage("MinLength"), minLength);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate maximum length
        /// </summary>
        public static bool ValidateMaxLength(string value, int maxLength, out string errorMessage)
        {
            errorMessage = null;

            if (value != null && value.Length > maxLength)
            {
                errorMessage = string.Format(GetMessage("MaxLength"), maxLength);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate range length
        /// </summary>
        public static bool ValidateRangeLength(string value, int minLength, int maxLength, out string errorMessage)
        {
            errorMessage = null;

            if (!ValidateRequired(value, out errorMessage))
                return false;

            if (value.Length < minLength || value.Length > maxLength)
            {
                errorMessage = string.Format(GetMessage("RangeLength"), minLength, maxLength);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate numeric range
        /// </summary>
        public static bool ValidateNumericRange(int value, int minValue, int maxValue, out string errorMessage)
        {
            errorMessage = null;

            if (value < minValue || value > maxValue)
            {
                errorMessage = string.Format(GetMessage("RangeValue"), minValue, maxValue);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate decimal range
        /// </summary>
        public static bool ValidateDecimalRange(decimal value, decimal minValue, decimal maxValue, out string errorMessage)
        {
            errorMessage = null;

            if (value < minValue || value > maxValue)
            {
                errorMessage = string.Format(GetMessage("RangeValue"), minValue, maxValue);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate password confirmation
        /// </summary>
        public static bool ValidatePasswordMatch(string password, string confirmPassword, out string errorMessage)
        {
            errorMessage = null;

            if (!ValidateRequired(password, out errorMessage))
                return false;

            if (!ValidateRequired(confirmPassword, out errorMessage))
                return false;

            if (password != confirmPassword)
            {
                errorMessage = GetMessage("PasswordMatch");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate date format
        /// </summary>
        public static bool ValidateDate(string dateString, out string errorMessage, out DateTime result)
        {
            errorMessage = null;
            result = DateTime.MinValue;

            if (!ValidateRequired(dateString, out errorMessage))
                return false;

            if (!DateTime.TryParseExact(dateString, "dd/MM/yyyy", null, 
                System.Globalization.DateTimeStyles.None, out result))
            {
                errorMessage = GetMessage("InvalidDate");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get custom validation message
        /// </summary>
        public static string GetMessage(string key)
        {
            string message;
            if (ValidationMessages.TryGetValue(key, out message))
            {
                return message;
            }
            return "⚠️ Dữ liệu không hợp lệ";
        }

        /// <summary>
        /// Add custom validation message
        /// </summary>
        public static void AddCustomMessage(string key, string message)
        {
            if (!ValidationMessages.ContainsKey(key))
            {
                ValidationMessages[key] = message;
            }
        }

        #endregion

        #region UI Helper Methods

        /// <summary>
        /// Show validation error message with icon
        /// </summary>
        public static void ShowError(string fieldName, string errorMessage)
        {
            string fullMessage = string.Format("【{0}】\n{1}", fieldName, errorMessage);
            MessageBox.Show(fullMessage, "❌ Lỗi Xác Thực", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Show success message
        /// </summary>
        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "✅ Thành Công", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show info message
        /// </summary>
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "ℹ️ Thông Tin", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Highlight control with error
        /// </summary>
        public static void HighlightError(Control control)
        {
            if (control == null) return;

            control.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
            control.Focus();
        }

        /// <summary>
        /// Clear highlight from control
        /// </summary>
        public static void ClearHighlight(Control control)
        {
            if (control == null) return;

            control.BackColor = System.Drawing.Color.White;
        }

        #endregion
    }
}