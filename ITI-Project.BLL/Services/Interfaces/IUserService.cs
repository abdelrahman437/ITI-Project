using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.BLL.Helpers;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Models.Enums;

namespace ITI_Project.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetInstructors();
        Task<Pagination<User>> GetAllAsync(string? search, UserRole? role, int pageIndex, int? pageSize);
        Task<User?> GetByIdAsync(int id);
        Task<UserViewModel?> GetByIdAsyncVM(int id);
        Task<User> AddAsync(User user);
        Task<User?> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsEmailUniqueAsync(string email, int? userId = null);
    }
}
