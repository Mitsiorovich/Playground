using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Infrastructure.Repositories
{
    public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(TaskBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
