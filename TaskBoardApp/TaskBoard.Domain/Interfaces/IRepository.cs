using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
