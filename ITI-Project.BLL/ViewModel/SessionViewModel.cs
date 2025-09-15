using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.BLL.Custom_Validation;
using ITI_Project.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.BLL.ViewModel
{
    public class SessionViewModel
    {
        public int SessionId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Trainee> trainee { get; set; } 
       
    }
    public class Trainee
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
