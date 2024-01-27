using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class NotificationRepository : INotificationRepository
{
    private TaskTrackerContextBase _dbContext;

    public NotificationRepository(TaskTrackerContextBase dbContext)
    {
        _dbContext = dbContext;
    }

    #region Create
    public async Task<Notification> Add(Notification notification)
    {
        // await _dbContext.Users.AddAsync(new User
        // {
        //     Id = 1,
        //     Name = "Roberto",
        //     IsDeleted = false
        // });
        // await _dbContext.Tasks.AddAsync(new DeskTask
        // {
        //     Id = 1,
        //     Name = "Cama",
        //     Description = "Hacer cama",
        //     UserId = 1,
        //     DueTime = DateTimeOffset.UtcNow,
        //     IsDeleted = false
        // });
        await _dbContext.Notifications.AddAsync(notification);
        await _dbContext.SaveChangesAsync();

        return notification;
    }
    #endregion

    #region Read
    public async Task<IEnumerable<Notification>> GetAll()
    {
        return await _dbContext.Notifications
        .AsNoTracking()
        .Include(x => x.DeskTask)
            .ThenInclude(x => x.User)
        .ToListAsync();
    }
    #endregion

    public async Task<Notification?> GetById(Guid id)
    {
        return await _dbContext.Notifications
        .AsNoTracking()
        .Include(x => x.DeskTask)
            .ThenInclude(x => x.User)
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();
    }

    #region Update
    public async Task<Notification?> Modify(Notification notification)
    {
        var dbNotification = await _dbContext.Notifications
        .Where(x => x.Id == notification.Id && !x.IsDeleted)
        .FirstOrDefaultAsync();

        if (dbNotification is not null)
        {
            dbNotification.Text = notification.Text;
            dbNotification.Delivered = notification.Delivered;
            dbNotification.DeliveredTime = notification.DeliveredTime;

            await _dbContext.SaveChangesAsync();
        }

        return dbNotification;
    }
    #endregion

    #region Delete
    public async Task<Notification?> Delete(Guid id)
    {
        var notification = await _dbContext.Notifications
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();

        if (notification is not null)
        {
            notification.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        return notification;
    }
    #endregion
}
