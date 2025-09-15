using ITI_Project.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ITI_Project.DAL.Repository
{
    public class GenericRepository<T> : GenaricRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

    }
}
