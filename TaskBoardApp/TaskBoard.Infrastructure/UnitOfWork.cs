using TaskBoard.Domain;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Infrastructure.Data;
using TaskBoard.Infrastructure.Repositories;

namespace TaskBoard.Infrastructure
{
    public class UnitOfWork : IUnitOfWork , IAsyncDisposable
    {
        public IUserRepository Users { get; }
        public IProjectRepository Projects { get; }

        public ITaskItemRepository TaskItems { get; }

        public IAttachmentRepository Attachments { get; }

        private readonly TaskBoardDbContext _dbContext;

        public UnitOfWork(TaskBoardDbContext dbContext)
        {
            _dbContext = dbContext;

            Users = new UserRepository(_dbContext);

            Projects = new ProjectRepository(_dbContext);

            TaskItems = new TaskItemRepository(_dbContext);

            Attachments = new AttachmentRepository(_dbContext);
        }



        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public ValueTask DisposeAsync()
        {
             return _dbContext.DisposeAsync();
        }
    }
}
