using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.DAL.Models
{

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required, EmailAddress, StringLength(100)]
        [Remote(action: "CheckEmail", controller: "User", AdditionalFields = nameof(UserId))]
        public string Email { get; set; } = null!;

        [Required]
        public UserRole Role { get; set; }

        public ICollection<Course>? CoursesTaught { get; set; }  
        public ICollection<Grade>? Grades { get; set; }          
    }
}
