using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface INotificationRepository
{
    Task<Notification> Add(Notification notification);
    Task<IEnumerable<Notification>> GetAll();
    Task<Notification?> GetById(Guid id);
    Task<Notification?> Modify(Notification notification);
    Task<Notification?> Delete(Guid id);
}