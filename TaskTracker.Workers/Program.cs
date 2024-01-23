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
    options.UseSqlite(@"Data Source=D:\Projects\Vagatasktracker-BE\TaskTrackerDB.db;");
});

/************************************************
* Dependency Injection 
************************************************/
builder.Services.AddSingleton<INotificationService, NotificationService>();

// Infrastructure DI only - API needs to DI into Application services
builder.Services.AddSingleton<ITaskTrackerContext, TaskTrackerSqLiteContext>();
builder.Services.AddSingleton<INotificationRepository, NotificationRepository>();

builder.Services.AddHostedService<NotificationWorker>();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<NotificationHub>("/hubs/notification");

app.Run();
