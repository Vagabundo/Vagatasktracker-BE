using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class TaskTrackerContextBase : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>/*, ITaskTrackerContext*/
{
    public TaskTrackerContextBase(DbContextOptions<TaskTrackerContextBase> options) : base(options) {}
    protected TaskTrackerContextBase(DbContextOptions options) : base(options) {}

    public DbSet<DeskTask> Tasks { set; get; }
    public DbSet<Notification> Notifications { set; get; }
    public DbSet<UserProfile> UserProfiles { set; get; }

    // needed only if using IDbContext
    //public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserProfile>().Property(b => b.IsDeleted).HasDefaultValue(false);
        //modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id);

        modelBuilder.Entity<DeskTask>().Property(b => b.IsDeleted).HasDefaultValue(false);

        modelBuilder.Entity<Notification>().Property(b => b.IsDeleted).HasDefaultValue(false);
    }
}