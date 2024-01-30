using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class TaskTrackerContextBase : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public TaskTrackerContextBase(DbContextOptions<TaskTrackerContextBase> options) : base(options) {}
    protected TaskTrackerContextBase(DbContextOptions options) : base(options) {}

    public DbSet<DeskTask> Tasks { set; get; }
    public DbSet<Notification> Notifications { set; get; }
    public DbSet<UserProfile> UserProfiles { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserProfile>().Property(b => b.IsDeleted).HasDefaultValue(false);
        //modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id);

        modelBuilder.Entity<DeskTask>().Property(b => b.IsDeleted).HasDefaultValue(false);

        modelBuilder.Entity<Notification>().Property(b => b.IsDeleted).HasDefaultValue(false);
    }
}