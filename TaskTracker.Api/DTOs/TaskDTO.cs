namespace TaskTracker.API.DTOs;

public class TaskDTO : BaseDTO
{  
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset DueTime { get; set; }
}