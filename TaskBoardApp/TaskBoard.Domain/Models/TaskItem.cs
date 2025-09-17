using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Domain.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }
    }
}
