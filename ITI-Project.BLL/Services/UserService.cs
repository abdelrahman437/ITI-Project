using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.BLL.Helpers;
using ITI_Project.BLL.Services.Interfaces;
using ITI_Project.BLL.Settings;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Models.Enums;
using ITI_Project.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ITI_Project.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<PaginationSetting> _settings;
        private readonly IGradeService _gradeService;

        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationSetting> settings, IGradeService gradeService)
        {
            _unitOfWork = unitOfWork;
            _settings = settings;
            _gradeService = gradeService;
        }
        public async Task<IEnumerable<User>> GetInstructors()
        {
            return await _unitOfWork.Users.GetInstructors();
        }

        public async Task<Pagination<User>> GetAllAsync(string? search, UserRole? role, int pageIndex, int? pageSize)
        {
            var query = _unitOfWork.Users.GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(u => u.Name.Contains(search));

            if (role.HasValue)
                query = query.Where(u => u.Role == role);

            int defaultPageSize = _settings.Value.PageSize;
            int effectivePageSize = pageSize ?? defaultPageSize;

            return await Pagination<User>.CreateAsync(query, pageIndex, effectivePageSize);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }
        public async Task<UserViewModel?> GetByIdAsyncVM(int id)
        {
            var query = _unitOfWork.Users.GetAllAsQueryable()
                                         .Where(e => e.UserId == id)
                                         .Include(e => e.CoursesTaught);

            var grades = await _gradeService.GetGradesPerTrainee(id);

            return await query.Select( e => new UserViewModel
            {
                UserId = e.UserId,
                Name = e.Name,
                Email = e.Email,
                Role = e.Role,
                grades = e.Role == UserRole.Trainee
                    ? grades
                    : new List<GradeViewModel>(),

                Courses = e.Role == UserRole.Instructor
                    ? e.CoursesTaught.Select(c => new CourseViewModel
                    {
                        CourseId = c.CourseId,
                        Name = c.Name
                    }).ToList()
                    : new List<CourseViewModel>()
            }).FirstOrDefaultAsync();
        }
        public async Task<List<UserViewModel>> GetAllAsyncVM(int id)
        {
            var query = _unitOfWork.Users.GetAllAsQueryable();
                                        
                                         

            var grades = await _gradeService.GetGradesPerTrainee(id);

            return await query.Select( e => new UserViewModel
            {
                UserId = e.UserId,
                Name = e.Name,
                Email = e.Email,
                Role = e.Role,
                grades = e.Role == UserRole.Trainee
                    ? grades
                    : new List<GradeViewModel>(),
            }).ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
                return false;

            _unitOfWork.Users.Delete(user);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        public async Task<bool> IsEmailUniqueAsync(string email, int? userId = null)
        {
            return !await _unitOfWork.Users
                .GetAllAsQueryable()
                .AnyAsync(u => u.Email == email && (userId == null || u.UserId != userId));
        }

    }
}
