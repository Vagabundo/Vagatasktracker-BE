using Microsoft.AspNetCore.SignalR;
using TaskTimelimit.Worker;

namespace TaskTimelimit.Hubs;
public class NotificationHub : Hub<INotification>
{
    public async Task SendTimeToClients(DateTime dateTime)
    {
        await Clients.All.SendNotification(dateTime);
    }
}