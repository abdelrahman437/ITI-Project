using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.BLL.Custom_Validation;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.BLL.ViewModel
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;
        public int? InstructorId { get; set; }
        public string InstructorName { get; set; }
    }
}
