using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface INotificationRepository
{
    Task<Notification> Add(Notification notification);
    Task<IEnumerable<Notification>> GetAll();
    Task<Notification?> GetById(int Id);
    Task<Notification?> Modify(Notification notification);
    Task<Notification?> Delete(int id);
}