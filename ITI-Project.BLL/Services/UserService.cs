using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var user = await _unitOfWork.Users.GetAllAsQueryable()
                .Where(e => e.UserId == id)
                .Include(e => e.CoursesTaught)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            var grades = user.Role == UserRole.Trainee
                ? await _gradeService.GetGradesPerTrainee(user.UserId)
                : new List<GradeViewModel>();

            return new UserViewModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                grades = grades,
                Courses = user.Role == UserRole.Instructor
                    ? user.CoursesTaught.Select(c => new CourseViewModel
                    {
                        CourseId = c.CourseId,
                        Name = c.Name
                    }).ToList()
                    : new List<CourseViewModel>()
            };
        }

        public async Task<List<UserViewModel>> GetAllAsyncVM(int traineeId)
        {
            var users = await _unitOfWork.Users.GetAllAsQueryable().ToListAsync();

            var result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var grades = user.Role == UserRole.Trainee
                    ? await _gradeService.GetGradesPerTrainee(traineeId)
                    : new List<GradeViewModel>();

                result.Add(new UserViewModel
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role,
                    grades = grades
                });
            }
            return result;
        }

        public async Task<User> AddAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await GetByIdAsync(user.UserId);
            if (existingUser == null)
                return null;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;

            await _unitOfWork.CompleteAsync();
            return existingUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
                return false;

            try
            {
                _unitOfWork.Users.Delete(user);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // هنا ممكن تسجل في Logs أن الحذف فشل بسبب FK constraints
                return false;
            }
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? userId = null)
        {
            return !await _unitOfWork.Users
                .GetAllAsQueryable()
                .AnyAsync(u => u.Email == email && (userId == null || u.UserId != userId));
        }
    }
}
