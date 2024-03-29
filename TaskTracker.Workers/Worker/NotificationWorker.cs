using Microsoft.AspNetCore.SignalR;
using TaskTracker.Worker.Hubs;
using TaskTracker.Application.Interfaces;

namespace TaskTracker.Worker;

/* https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-8.0&tabs=netcore-cli */

public class NotificationWorker : BackgroundService, IDisposable
{
    private int executionCount = 0;
    private readonly ILogger<NotificationWorker> _logger;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly INotificationService _notificationService;

    public NotificationWorker(ILogger<NotificationWorker> logger, IHubContext<NotificationHub> hubContext, INotificationService notificationService)
    {
        _logger = logger;
        _hubContext = hubContext;
        _notificationService = notificationService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            var count = Interlocked.Increment(ref executionCount);
            _logger.LogInformation("Notifications Service is working. Count: {Count}", count);
            // Check the database for events that need notifications
            // If found, trigger SignalR broadcasting
            await CheckDatabaseAndBroadcast();
        }
    }

    private async Task CheckDatabaseAndBroadcast()
    {
        var eventsToNotify = await _notificationService.GetEventsToNotify();
        _logger.LogInformation($"{eventsToNotify.ToList().Count} notifications to check");
        foreach (var notification in eventsToNotify)
        {
            _logger.LogInformation($"Checking notification: {notification.Id}");
            // TODO: for multiusers, check if notification's user is connected using claims, then proceed
            // In this scenario, we assume there is only one client and it is always connected (running in local PC)
            // Trigger SignalR broadcasting for each event
            // await _hubContext.Clients.User(notification.DeskTask.UserId.ToString()).SendAsync("Notification", notification.DeskTask.Name, notification.DeskTask.Description);
            await _hubContext.Clients.All.SendAsync("Notification", notification.DeskTask.Name, notification.DeskTask.Description);
            notification.Delivered = true;
            notification.DeliveredTime = DateTimeOffset.UtcNow;
            await _notificationService.Update(notification);
        }
    }
}