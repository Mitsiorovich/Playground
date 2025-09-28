using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(TaskBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
