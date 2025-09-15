using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.DAL.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [Required]
        public int SessionId { get; set; }
        [ForeignKey(nameof(SessionId))]
        public Session? Session { get; set; }

        [Required]
        public int TraineeId { get; set; }
        [ForeignKey(nameof(TraineeId))]
        public User? Trainee { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public decimal Value { get; set; }
    }
}
