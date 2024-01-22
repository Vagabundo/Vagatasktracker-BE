using Microsoft.EntityFrameworkCore;
using TaskTimelimit.Worker;
using TaskTimelimit.Hubs;
using TaskTracker.Database;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services;

var builder = WebApplication.CreateBuilder(args);

/************************************************
* Add connection string to services container - using EF pooling for performance
************************************************/
builder.Services.AddDbContextPool<TaskTrackerInMemoryContext>(options => options.UseInMemoryDatabase("TaskTrackerInMemoryDatabase"));

/************************************************
* Dependency Injection 
************************************************/
builder.Services.AddSingleton<INotificationService, NotificationService>();

// Infrastructure DI only - API needs to DI into Application services
builder.Services.AddSingleton<ITaskTrackerContext, TaskTrackerInMemoryContext>();
builder.Services.AddSingleton<INotificationRepository, NotificationRepository>();

builder.Services.AddHostedService<NotificationWorker>();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<NotificationHub>("/hubs/notification");

app.Run();
