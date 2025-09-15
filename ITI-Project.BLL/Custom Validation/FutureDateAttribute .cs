using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.BLL.Custom_Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue.Date >= DateTime.Now.Date;
            }
            return true;
        }
    }
}
