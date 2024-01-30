using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Database;

public class TaskTrackerSqLiteContext : TaskTrackerContextBase
{
    public TaskTrackerSqLiteContext(DbContextOptions<TaskTrackerSqLiteContext> options) : base(options) {}
}

