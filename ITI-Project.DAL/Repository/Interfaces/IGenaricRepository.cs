using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITI_Project.DAL.Repository.Interfaces
{
    public interface GenaricRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllAsQueryable();
        Task<T?> GetByIdAsync(int id); 
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);
        Task<int> CountAsync();
    }
}
