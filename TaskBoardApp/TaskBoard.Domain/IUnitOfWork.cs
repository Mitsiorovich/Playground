using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Domain
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IProjectRepository Projects { get; }
        ITaskItemRepository TaskItems { get; }
        IAttachmentRepository Attachments { get; }
        Task SaveChangesAsync();
    }
}
