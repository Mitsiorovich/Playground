namespace TaskBoard.Application.DTOs
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }
    }
}
