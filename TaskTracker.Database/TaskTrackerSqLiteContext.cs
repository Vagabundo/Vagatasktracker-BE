using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class TaskTrackerSqLiteContext : TaskTrackerContextBase
{
    public TaskTrackerSqLiteContext(DbContextOptions<TaskTrackerSqLiteContext> options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=D:\Projects\Vagatasktracker-BE\TaskTrackerDB.db;Version=3;");
    }
}

