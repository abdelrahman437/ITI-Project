using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITI_Project.DAL.Custom_Validation;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.DAL.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Course Name must be between 3 and 50 characters.")]
        [NoNumber(ErrorMessage = "Course Name must not contain numbers.")]
        [Remote(action: "IsCourseNameAvailable", controller: "Course", AdditionalFields = nameof(CourseId))]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = null!;
        public int? InstructorId { get; set; }
        [ForeignKey(nameof(InstructorId))]
        public User? Instructor { get; set; }
        public ICollection<Session>? Sessions { get; set; }
    }
}
