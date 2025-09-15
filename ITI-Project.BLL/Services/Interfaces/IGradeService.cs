using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.BLL.Helpers;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;

namespace ITI_Project.BLL.Services.Interfaces
{
    public interface IGradeService
    {
        Task<List<GradeViewModel>> GetGradesPerTrainee(int id);
        Task<Pagination<UserViewModel>> UsersWithGrades(int pageIndex, int? pageSize);
        Task AddGradeAsync(int traineeId, int sessionId, decimal value);
    }
}
