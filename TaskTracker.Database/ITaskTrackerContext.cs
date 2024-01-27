using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public interface ITaskTrackerContext
{
    public DbSet<DeskTask> Tasks { set; get; }
    public DbSet<Notification> Notifications { set; get; }
    public DatabaseFacade Database  { get; }
    public Task<int> SaveChangesAsync();
}