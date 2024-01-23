using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Database;

public class TaskTrackerInMemoryContext : TaskTrackerContextBase
{
    public TaskTrackerInMemoryContext(DbContextOptions<TaskTrackerInMemoryContext> options) : base(options) {}
}