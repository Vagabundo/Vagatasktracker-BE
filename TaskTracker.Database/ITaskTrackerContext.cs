using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public interface ITaskTrackerContext
{
    public DbSet<User> Users { set; get; }
    public DbSet<DeskTask> Tasks { set; get; }
    public DbSet<Notification> Notifications { set; get; }
    public Task<int> SaveChangesAsync();
}