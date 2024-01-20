using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class TaskTrackerContextBase : DbContext, ITaskTrackerContext
{
    public TaskTrackerContextBase(DbContextOptions<TaskTrackerContextBase> options) : base(options) {}
    protected TaskTrackerContextBase(DbContextOptions options) : base(options) {}

    public DbSet<User> Users { set; get; }
    public DbSet<DeskTask> Tasks { set; get; }
    public DbSet<Notification> Notifications { set; get; }

    public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
}