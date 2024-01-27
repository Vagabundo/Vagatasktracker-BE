using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Database;

public class TaskTrackerSqLiteContext : TaskTrackerContextBase
{
    public TaskTrackerSqLiteContext(DbContextOptions<TaskTrackerSqLiteContext> options) : base(options) {}
    
    // Can't run ef migrations with this bit
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite(@"Data Source=D:\Projects\Vagatasktracker-BE\TaskTrackerDB.db;Version=3;");
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskTrackerSqLiteContext).Assembly);
    // }
}

