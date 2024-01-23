using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services;
using TaskTracker.Database;

var builder = WebApplication.CreateBuilder(args);

/************************************************
* Add connection string to services container - using EF pooling for performance
************************************************/
// builder.Services.AddDbContextPool<TaskTrackerInMemoryContext>(options => options.UseInMemoryDatabase("TaskTrackerInMemoryDatabase"));
builder.Services.AddDbContextPool<TaskTrackerSqLiteContext>(options => 
{
    options.UseSqlite(@"Data Source=D:\Projects\Vagatasktracker-BE\TaskTrackerDB.db;");
});
// builder.Services.AddDbContextPool<TaskTrackerSQLServerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TaskTrackerSQLServerDatabase")));


/************************************************
* Dependency Injection 
************************************************/
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// Infrastructure DI only - API needs to DI into Application services
builder.Services.AddScoped<ITaskTrackerContext, TaskTrackerSqLiteContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
