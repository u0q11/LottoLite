using System;
using System.ComponentModel.DataAnnotations;

namespace LottoLite.Web.Validation
{
    public class DateRequiredAttribute : ValidationAttribute
    {
        public DateRequiredAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime))
            {
                throw new ValidationException("DateRequired can only be used on DateTime types.");
            }
            else
            {
                if ((DateTime)value == DateTime.MinValue)
                    return new ValidationResult(this.FormatErrorMessage(validationContext.MemberName));
                else
                    return ValidationResult.Success;
            }

        }

    }
}