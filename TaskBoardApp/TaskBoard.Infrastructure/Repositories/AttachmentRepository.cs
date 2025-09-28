using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Infrastructure.Repositories
{
    public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(TaskBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
