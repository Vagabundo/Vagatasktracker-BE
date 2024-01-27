using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface INotificationService
{
    Task<Notification> Add(Notification entity);
    Task<Notification?> Delete(Guid id);
    Task<Notification?> Get(Guid id);
    Task<IEnumerable<Notification>> GetAll();
    Task<IEnumerable<Notification>> GetEventsToNotify();
    Task<Notification?> Update(Notification entity);
}