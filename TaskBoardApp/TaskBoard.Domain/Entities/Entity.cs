using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
