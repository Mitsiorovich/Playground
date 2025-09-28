using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Models
{
    public class TaskItem : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public Guid StateId { get; set; }
        public State State { get; set; } = null!;

        public Guid SprintId { get; set; }
        public Sprint Sprint { get; set; } = null!;

        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
