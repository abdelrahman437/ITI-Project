using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Repository.Interfaces;

namespace ITI_Project.DAL.Repository
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        public GradeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
