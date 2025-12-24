using System;
using System.Collections.Generic;

namespace QLBanSach_GUI.Utilities
{
    /// <summary>
    /// Usage guide for ValidationManager and DialogValidationHelper
    /// </summary>
    public class ValidationGuide
    {
        /*
         * ==================== VALIDATION MANAGER USAGE ====================
         * 
         * 1. BASIC FIELD VALIDATION:
         * 
         *    string errorMessage;
         *    if (!ValidationManager.ValidateRequired(txtName.Text, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Tên", errorMessage);
         *        ValidationManager.HighlightError(txtName);
         *        return false;
         *    }
         * 
         * 
         * 2. EMAIL VALIDATION:
         * 
         *    if (!ValidationManager.ValidateEmail(txtEmail.Text, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Email", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * 3. PHONE VALIDATION:
         * 
         *    if (!ValidationManager.ValidatePhone(txtPhone.Text, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Điện thoại", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * 4. NUMERIC VALIDATION:
         * 
         *    int quantity;
         *    if (!ValidationManager.ValidateNumeric(txtQty.Text, out errorMessage, out quantity))
         *    {
         *        ValidationManager.ShowError("Số lượng", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * 5. DECIMAL VALIDATION:
         * 
         *    decimal price;
         *    if (!ValidationManager.ValidateDecimal(txtPrice.Text, out errorMessage, out price))
         *    {
         *        ValidationManager.ShowError("Giá", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * 6. LENGTH VALIDATION:
         * 
         *    // Min length (at least 5 characters)
         *    if (!ValidationManager.ValidateMinLength(txtPassword.Text, 5, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Mật khẩu", errorMessage);
         *        return false;
         *    }
         *    
         *    // Max length (no more than 20 characters)
         *    if (!ValidationManager.ValidateMaxLength(txtName.Text, 20, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Tên", errorMessage);
         *        return false;
         *    }
         *    
         *    // Range length (5-20 characters)
         *    if (!ValidationManager.ValidateRangeLength(txtUsername.Text, 5, 20, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Tên đăng nhập", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * 7. RANGE VALIDATION:
         * 
         *    decimal price = decimal.Parse(txtPrice.Text);
         *    if (!ValidationManager.ValidateDecimalRange(price, 0m, 10000000m, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Giá", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * 8. PASSWORD MATCH VALIDATION:
         * 
         *    if (!ValidationManager.ValidatePasswordMatch(txtPassword.Text, 
         *        txtConfirmPassword.Text, out errorMessage))
         *    {
         *        ValidationManager.ShowError("Mật khẩu", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * 9. DATE VALIDATION:
         * 
         *    DateTime date;
         *    if (!ValidationManager.ValidateDate(txtDate.Text, out errorMessage, out date))
         *    {
         *        ValidationManager.ShowError("Ngày tháng", errorMessage);
         *        return false;
         *    }
         * 
         * 
         * ==================== DIALOG VALIDATION HELPER USAGE ====================
         * 
         * 1. CREATE AND ADD FIELDS:
         * 
         *    private DialogValidationHelper validator = new DialogValidationHelper();
         *    
         *    private void FrmMyDialog_Load(object sender, EventArgs e)
         *    {
         *        validator.AddField(txtName, "Tên", 
         *            DialogValidationHelper.ValidationType.Required);
         *        validator.AddField(txtEmail, "Email", 
         *            DialogValidationHelper.ValidationType.Email);
         *        validator.AddField(txtPhone, "Điện thoại", 
         *            DialogValidationHelper.ValidationType.Phone);
         *        validator.AddField(txtPrice, "Giá", 
         *            DialogValidationHelper.ValidationType.Decimal);
         *    }
         * 
         * 
         * 2. VALIDATE ON FORM CLOSE:
         * 
         *    private void btnOK_Click(object sender, EventArgs e)
         *    {
         *        if (validator.ValidateAll())
         *        {
         *            this.DialogResult = DialogResult.OK;
         *            this.Close();
         *        }
         *    }
         * 
         * 
         * 3. VALIDATE WITH CONSTRAINTS:
         * 
         *    validator.AddField(txtUsername, "Tên đăng nhập", 
         *        DialogValidationHelper.ValidationType.RangeLength, 5, 20);
         *    
         *    validator.AddField(txtQuantity, "Số lượng", 
         *        DialogValidationHelper.ValidationType.NumericRange, 1, 1000);
         * 
         * 
         * ==================== CUSTOM MESSAGES ====================
         * 
         *    // Add custom validation message
         *    ValidationManager.AddCustomMessage("CustomRule", 
         *        "⚠️ Giá trị không hợp lệ theo quy tắc tùy chỉnh");
         * 
         * 
         * ==================== MESSAGE DISPLAY ====================
         * 
         *    // Show error
         *    ValidationManager.ShowError("Tên sách", "Vui lòng nhập tên sách");
         *    
         *    // Show success
         *    ValidationManager.ShowSuccess("Sách đã được thêm thành công!");
         *    
         *    // Show info
         *    ValidationManager.ShowInfo("Vui lòng điền đầy đủ thông tin");
         * 
         */
    }
}