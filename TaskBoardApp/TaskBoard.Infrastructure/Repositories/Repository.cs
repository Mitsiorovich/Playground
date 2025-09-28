using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private TaskBoardDbContext _dbContext { get; set; }

        public Repository(TaskBoardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await this._dbContext.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            this._dbContext.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await
                this._dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Update(T entity)
        {
            this._dbContext.Update(entity);
        }
    }
}
