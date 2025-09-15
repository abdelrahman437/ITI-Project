using ITI_Project.BLL.Helpers;
using ITI_Project.BLL.ViewModel;
using ITI_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.BLL.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Pagination<CourseViewModel>> GetPagedAsync(string? search, string? category, int pageIndex, int? pageSize);
        Task<ICollection<string>> getcategories();
        Task<bool> IsNameExistAsync(string name, int? excludeId);

        Task<int> CountAsync(string? search);
        Task<Course?> GetByIdAsync(int id);
        Task<CourseViewModel> GetByIdAsyncVM(int id);
        Task AddAsync(Course course);
        void Update(Course course);
        void Delete(int id);
        Task<List<Course>> GetCoursesName();
        Task SaveAsync();
    }
}
