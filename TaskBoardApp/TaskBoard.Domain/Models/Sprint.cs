using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Models
{
    public class Sprint : Entity
    {
        public string Name { get; set; } = string.Empty;

        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public ICollection<State> States { get; set; } = new List<State>();

        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }
}
