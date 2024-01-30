using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services;
using TaskTracker.Database;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

/************************************************
* Add connection string to services container - using EF pooling for performance
************************************************/
// builder.Services.AddDbContextPool<TaskTrackerInMemoryContext>(options => options.UseInMemoryDatabase("TaskTrackerInMemoryDatabase"));
builder.Services.AddDbContextPool<TaskTrackerSqLiteContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteTaskTrackerDatabase"));
});

/************************************************
* Dependency Injection 
************************************************/
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// Infrastructure DI only - API needs to DI into Application services
builder.Services.AddScoped<TaskTrackerContextBase, TaskTrackerSqLiteContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

// Add services to the container.
builder.Services.AddControllers();

// Add Auth
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication();

builder.Services.AddIdentityApiEndpoints<IdentityUser<Guid>>()
    .AddEntityFrameworkStores<TaskTrackerSqLiteContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<IdentityUser<Guid>>();
app.MapControllers();

app.Run();
