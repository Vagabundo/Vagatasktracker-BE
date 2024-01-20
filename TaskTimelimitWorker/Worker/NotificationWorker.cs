namespace TaskTimelimit.Worker;

/* https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-8.0&tabs=netcore-cli */

public class NotificationWorker : BackgroundService, IDisposable
{
    private int executionCount = 0;
    private readonly ILogger<NotificationWorker> _logger;

    public NotificationWorker(ILogger<NotificationWorker> logger)
    {
        _logger = logger;
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
            // CheckDatabaseAndBroadcast();
        }
    }


    // private void CheckDatabaseAndBroadcast()
    // {
    //     using (var dbContext = new YourDbContext())
    //     {
    //         var eventsToNotify = dbContext.Events
    //             .Where(e => e.EventDateTime <= DateTime.UtcNow && !e.IsNotified)
    //             .ToList();

    //         foreach (var event in eventsToNotify)
    //         {
    //             // Trigger SignalR broadcasting for each event
    //             // Example: NotifyClients(event);
    //             event.IsNotified = true;
    //         }

    //         dbContext.SaveChanges();
    //     }
    // }

    // private void NotifyClients(Event eventData)
    // {
    //     var hubContext = GlobalHost.ConnectionManager.GetHubContext<YourHub>();
    //     hubContext.Clients.All.SendAsync("ReceiveNotification", eventData);
    // }
}