using Microsoft.AspNetCore.Identity;
using TaskTracker.Domain;

namespace TaskTracker.Worker.Hubs;

public interface INotification
{
    Task SendNotification(IdentityUser user, Notification notification);
}