using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.BLL.ViewModel
{
    public class GradeViewModel
    {
        public int TraineeId { get; set; }
        public int GradeId { get; set; }
        public decimal Value { get; set; }
        public int SessionId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
