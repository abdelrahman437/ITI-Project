using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ITI_Project.BLL.Custom_Validation
{
    public class NoNumberAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success; 

            string strValue = value.ToString()!;
            if (strValue.Any(char.IsDigit))
            {
                return new ValidationResult(ErrorMessage ?? "Numbers are not allowed.");
            }

            return ValidationResult.Success;
        }
    }
}
