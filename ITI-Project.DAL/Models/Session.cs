using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITI_Project.DAL.Custom_Validation;

namespace ITI_Project.DAL.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Start date cannot be in the past.")]
        public DateTime StartDate { get; set; }

        [Required]
        [DateGreater("StartDate", ErrorMessage = "End date must be after Start date.")]
        public DateTime EndDate { get; set; }

        public IEnumerable<Grade>? Grades { get; set; }
    }
}
