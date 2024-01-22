using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface INotificationService
{
    Task<Notification> Add(Notification entity);
    Task<Notification?> Delete(int id);
    Task<Notification?> Get(int Id);
    Task<IEnumerable<Notification>> GetAll();
    Task<IEnumerable<Notification>> GetEventsToNotify();
    Task<Notification?> Update(Notification entity);
}