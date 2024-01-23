using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Database;

public class TaskTrackerSQLServerContext : TaskTrackerContextBase
{
    public TaskTrackerSQLServerContext(DbContextOptions<TaskTrackerSQLServerContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("ConnectionString");
    }
}

