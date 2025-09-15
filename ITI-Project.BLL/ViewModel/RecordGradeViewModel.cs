using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_Project.BLL.ViewModel
{
    public class RecordGradeViewModel
    {
        public int TraineeId { get; set; }
        public string? TraineeName { get; set; }

        [Required]
        public int SelectedCourseId { get; set; }

        [Required]
        public int SelectedSessionId { get; set; }

        public IEnumerable<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
        
        public IEnumerable<SelectListItem> Sessions { get; set; } = new List<SelectListItem>();

        [Required]
        [Range(0, 100)]
        public decimal Value { get; set; }
    }

}
