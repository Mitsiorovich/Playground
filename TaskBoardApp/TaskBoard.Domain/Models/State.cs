using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Models
{
    public class State : Entity
    {
        public string Name { get; set; } = string.Empty;
    }
}