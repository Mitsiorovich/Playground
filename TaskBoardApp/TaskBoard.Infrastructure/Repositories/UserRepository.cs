using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TaskBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
