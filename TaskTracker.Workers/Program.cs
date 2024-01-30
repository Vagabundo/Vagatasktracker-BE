using Microsoft.EntityFrameworkCore;
using TaskTracker.Worker;
using TaskTracker.Worker.Hubs;
using TaskTracker.Database;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services;

var builder = WebApplication.CreateBuilder(args);

/************************************************
* Add connection string to services container - using EF pooling for performance
************************************************/
builder.Services.AddDbContextPool<TaskTrackerSqLiteContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteTaskTrackerDatabase"));
});

/************************************************
* Dependency Injection 
************************************************/
builder.Services.AddSingleton<INotificationService, NotificationService>();

// Infrastructure DI only - API needs to DI into Application services
builder.Services.AddSingleton<TaskTrackerContextBase, TaskTrackerSqLiteContext>();
builder.Services.AddSingleton<INotificationRepository, NotificationRepository>();

builder.Services.AddHostedService<NotificationWorker>();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<NotificationHub>("/hubs/notification");

app.Run();
