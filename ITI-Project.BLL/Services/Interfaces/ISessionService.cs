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
    public interface ISessionService
    {
        Task<Session> GetSessionAsync(int id);
        Task<SessionViewModel?> GetSessionAsyncVM(int id);
        Task<Pagination<SessionViewModel>> GetAllAsync(string courseName, int pageIndex, int? pageSize);        
        Task<bool> UpdateSessionAsync(Session model);
        Task<bool> CreateSessionAsync(Session model);
        Task<bool> DeleteSessionAsync(int id);
        Task<List<Session>> GetByCourseId(int id);
    }
}
