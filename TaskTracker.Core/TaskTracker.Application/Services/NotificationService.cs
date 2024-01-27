using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Application.Services;

public class NotificationService : INotificationService
{
    private INotificationRepository _notificationRepository;

    public NotificationService (INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<Notification> Add(Notification entity)
    {
        return await _notificationRepository.Add(entity);
    }

    public async Task<Notification?> Get(Guid id)
    {
        return await _notificationRepository.GetById(id);
    }

    public async Task<IEnumerable<Notification>> GetAll()
    {
        return await _notificationRepository.GetAll();
    }

    public async Task<IEnumerable<Notification>> GetEventsToNotify()
    {
        var all = await GetAll();
        return all.Where(x => !x.IsDeleted && !x.Delivered && x.DeskTask.DueTime < DateTimeOffset.UtcNow.AddMinutes(10)) ?? new List<Notification>();
    }

    public async Task<Notification?> Delete(Guid id)
    {
        return await _notificationRepository.Delete(id);
    }

    public async Task<Notification?> Update(Notification entity)
    {
        return await _notificationRepository.Modify(entity);
    }
}