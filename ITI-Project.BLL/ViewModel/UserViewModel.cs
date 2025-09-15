using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.BLL.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; }
        public List<GradeViewModel> grades { get; set; } = new();
        public List<CourseViewModel> Courses { get; set; } = new();

    }
}
