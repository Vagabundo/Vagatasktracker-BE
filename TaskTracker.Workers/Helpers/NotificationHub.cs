using Microsoft.AspNetCore.SignalR;
using TaskTimelimit.Worker;
using TaskTracker.Domain;

namespace TaskTimelimit.Hubs;
public class NotificationHub : Hub<INotification>
{
    // replace this with claims, auth and that stuff for multiusers
    static HashSet<string> CurrentConnections = new HashSet<string>();

    public override async Task OnConnectedAsync()
    {
        var id = Context.ConnectionId;
        CurrentConnections.Add(id);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connection = CurrentConnections.FirstOrDefault(x => x == Context.ConnectionId);
        if (connection is not null)
        {
            CurrentConnections.Remove(connection);
        }

        await base.OnDisconnectedAsync(exception);
    }

    //return list of all active connections
    public List<string> GetAllActiveConnections()
    {
        return CurrentConnections.ToList();
    }
}