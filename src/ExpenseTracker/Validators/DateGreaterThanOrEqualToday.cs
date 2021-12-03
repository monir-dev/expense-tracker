using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Validators
{
    public class DateGreaterThanOrEqualToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if (dt >= DateTime.Now)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Make sure your date is >= than today");
        }
    }
}
