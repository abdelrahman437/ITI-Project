using System;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.DAL.Custom_Validation
{
    public class DateGreaterAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
            ErrorMessage = "End Date must be greater than Start Date.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = value as DateTime?;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);


            var comparisonValue = property.GetValue(validationContext.ObjectInstance) as DateTime?;

            if (currentValue.HasValue && comparisonValue.HasValue && currentValue <= comparisonValue)
            {
                return new ValidationResult(string.Format(ErrorMessage,validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
