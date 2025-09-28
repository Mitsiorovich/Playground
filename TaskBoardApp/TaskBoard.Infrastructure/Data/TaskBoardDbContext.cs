using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Data
{
    public class TaskBoardDbContext : DbContext
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}
