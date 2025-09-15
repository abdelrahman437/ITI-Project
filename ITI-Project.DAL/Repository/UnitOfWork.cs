using ITI_Project.DAL;
using ITI_Project.DAL.Repository;
using ITI_Project.DAL.Repository.Interfaces;

namespace ITI_Project.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ICourseRepository? _courses;
        private ISessionRepository? _session;
        private IGradeRepository? _Grades;
        private IUserRepository? _Users;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICourseRepository Courses => _courses ??= new CourseRepository(_context);
        public ISessionRepository Sessions => _session ??= new SessionRepository(_context);
        public IGradeRepository Grades => _Grades ??= new GradeRepository(_context);
        public IUserRepository Users => _Users ??= new UserRepository(_context);


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
