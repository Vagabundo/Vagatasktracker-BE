using TaskTracker.Domain;

namespace TaskTracker.Worker.Hubs;

public interface INotification
{
    Task SendNotification(User user, Notification notification);
}