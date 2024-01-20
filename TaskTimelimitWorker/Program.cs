//using Microsoft.EntityFrameworkCore;
using TaskTimelimit.Worker;
using TaskTimelimit.Hubs;
//using TaskTracker.Database;

var builder = WebApplication.CreateBuilder(args);

/************************************************
* Add connection string to services container - using EF pooling for performance
************************************************/
//builder.Services.AddDbContextPool<TaskTrackerInMemoryContext>(options => options.UseInMemoryDatabase("TaskTrackerInMemoryDatabase"));
//builder.Services.AddDbContextPool<TaskTrackerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TaskTrackerSQLServerDatabase")));

builder.Services.AddHostedService<NotificationWorker>();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<NotificationHub>("/hubs/notification");

app.Run();
