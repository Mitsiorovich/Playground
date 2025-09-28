using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Models
{
    public class Project : Entity
    {
        public string Name { get; set; } = string.Empty;

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
    }
}
