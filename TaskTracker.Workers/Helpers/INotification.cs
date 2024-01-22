using Microsoft.Data.SqlClient;
using TaskTracker.Domain;

namespace TaskTimelimit.Worker;

public interface INotification
{
    Task SendNotification(User user, Notification notification);
}