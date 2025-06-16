using Microsoft.EntityFrameworkCore;
using MiniTaskManager.Model;

namespace MiniTaskManager.Controllers
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskDetails> Tasks { get; set; }
    }
}
