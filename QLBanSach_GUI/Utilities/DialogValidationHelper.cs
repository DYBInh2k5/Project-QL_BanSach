using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLBanSach_GUI.Utilities
{
    /// <summary>
    /// Helper class for dialog form validation
    /// </summary>
    public class DialogValidationHelper
    {
        private List<ValidationField> validationFields = new List<ValidationField>();

        public class ValidationField
        {
            public Control Control { get; set; }
            public string FieldName { get; set; }
            public ValidationType ValidationRule { get; set; }
            public int MinValue { get; set; }
            public int MaxValue { get; set; }
            public string CustomMessage { get; set; }
        }

        public enum ValidationType
        {
            Required,
            Email,
            Phone,
            Numeric,
            Decimal,
            MinLength,
            MaxLength,
            RangeLength,
            NumericRange
        }

        /// <summary>
        /// Add validation field
        /// </summary>
        public void AddField(Control control, string fieldName, ValidationType validationType, 
            int minValue = 0, int maxValue = 0)
        {
            validationFields.Add(new ValidationField
            {
                Control = control,
                FieldName = fieldName,
                ValidationRule = validationType,
                MinValue = minValue,
                MaxValue = maxValue
            });
        }

        /// <summary>
        /// Validate all fields
        /// </summary>
        public bool ValidateAll()
        {
            ClearAllHighlights();

            foreach (var field in validationFields)
            {
                if (!ValidateField(field))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Validate single field
        /// </summary>
        private bool ValidateField(ValidationField field)
        {
            if (field.Control == null) return true;

            string value = field.Control.Text;
            string errorMessage = null;

            switch (field.ValidationRule)
            {
                case ValidationType.Required:
                    if (!ValidationManager.ValidateRequired(value, out errorMessage))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.Email:
                    if (!ValidationManager.ValidateEmail(value, out errorMessage))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.Phone:
                    if (!ValidationManager.ValidatePhone(value, out errorMessage))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.Numeric:
                    int numResult;
                    if (!ValidationManager.ValidateNumeric(value, out errorMessage, out numResult))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.Decimal:
                    decimal decResult;
                    if (!ValidationManager.ValidateDecimal(value, out errorMessage, out decResult))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.MinLength:
                    if (!ValidationManager.ValidateMinLength(value, field.MinValue, out errorMessage))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.MaxLength:
                    if (!ValidationManager.ValidateMaxLength(value, field.MaxValue, out errorMessage))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.RangeLength:
                    if (!ValidationManager.ValidateRangeLength(value, field.MinValue, 
                        field.MaxValue, out errorMessage))
                    {
                        ShowFieldError(field, errorMessage);
                        return false;
                    }
                    break;

                case ValidationType.NumericRange:
                    if (int.TryParse(value, out int rangeNum))
                    {
                        if (!ValidationManager.ValidateNumericRange(rangeNum, 
                            field.MinValue, field.MaxValue, out errorMessage))
                        {
                            ShowFieldError(field, errorMessage);
                            return false;
                        }
                    }
                    break;
            }

            return true;
        }

        /// <summary>
        /// Show field error with highlight
        /// </summary>
        private void ShowFieldError(ValidationField field, string errorMessage)
        {
            ValidationManager.HighlightError(field.Control);
            ValidationManager.ShowError(field.FieldName, errorMessage);
        }

        /// <summary>
        /// Clear all highlights
        /// </summary>
        private void ClearAllHighlights()
        {
            foreach (var field in validationFields)
            {
                ValidationManager.ClearHighlight(field.Control);
            }
        }

        /// <summary>
        /// Clear validation fields
        /// </summary>
        public void Clear()
        {
            validationFields.Clear();
        }
    }
}