using TaskBoard.Domain.Entities;
namespace TaskBoard.Domain.Models
{
    public class Attachment : Entity
    {
        public string Name { get; set; } = string.Empty;

        public string FileUrl { get; set; } = string.Empty;

        public Guid TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; } = null!;
    }
}
