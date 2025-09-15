using System.Threading.Tasks;
using ITI_Project.BLL.Helpers;
using ITI_Project.BLL.Interfaces;
using ITI_Project.BLL.Settings;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ITI_Project.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<PaginationSetting> _settings;

        public CourseService(IUnitOfWork unitOfWork, IOptions<PaginationSetting> settings)
        {
            _unitOfWork = unitOfWork;
            _settings = settings;
        }
        public async Task<Pagination<CourseViewModel>> GetPagedAsync(string? search, string? category, int pageIndex, int? pageSize)
        {
            var query = _unitOfWork.Courses.GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(c => c.Name.Contains(search));

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(c => c.Category == category);

            int defaultPageSize = _settings.Value.PageSize;
            int effectivePageSize = pageSize ?? defaultPageSize;
            var query1 = query.OrderBy(c => c.CourseId).Include(e=>e.Instructor).Select(course => new CourseViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Category = course.Category,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor != null ? course.Instructor.Name : "Unknown Instructor"
            });
            return await Pagination<CourseViewModel>.CreateAsync(query1, pageIndex, effectivePageSize);
        }


        public async Task<int> CountAsync(string? search)
        {
            var query = _unitOfWork.Courses.GetAllAsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(c => c.Name.Contains(search) || c.Category.Contains(search));
            return await query.CountAsync();
        }
        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Courses.GetByIdAsync(id);
        }
        public async Task<CourseViewModel?> GetByIdAsyncVM(int id) 
            => await _unitOfWork.Courses.GetAllAsQueryable().Include(e=>e.Instructor).Select(course => new CourseViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Category = course.Category,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor != null ? course.Instructor.Name : "Unknown Instructor"
            }).FirstOrDefaultAsync(e=>e.CourseId == id);

        public async Task AddAsync(Course course) => await _unitOfWork.Courses.AddAsync(course);

        public void Update(Course course) => _unitOfWork.Courses.Update(course);

        public void Delete(int id)
        {

            Course course = new Course { CourseId = id };
            _unitOfWork.Courses.Delete(course);

        }

       public async Task<List<Course>> GetCoursesName()
        {
            return await _unitOfWork.Courses.GetAllAsQueryable().Select(e => new Course
            {
                CourseId = e.CourseId,
                Name = e.Name,
            }).ToListAsync();
        }

        public async Task SaveAsync() => await _unitOfWork.CompleteAsync();

        public async Task<ICollection<string>> getcategories()
        {
            return await _unitOfWork.Courses.GetAllAsQueryable().Select(e => e.Category).Distinct().ToListAsync();
        }
        public async Task<bool> IsNameExistAsync(string name, int? excludeId = null)
        {
            return await _unitOfWork.Courses.GetAllAsQueryable()
                .AnyAsync(c => c.Name == name && (excludeId == null || c.CourseId != excludeId));
        }
        public async Task<IEnumerable<Course>> GetAllAsync() => await _unitOfWork.Courses.GetAllAsync();
    }
}
