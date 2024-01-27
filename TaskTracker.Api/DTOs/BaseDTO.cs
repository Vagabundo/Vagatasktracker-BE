namespace TaskTracker.API.DTOs;

public class BaseDTO
{  
    public Guid Id { get; set; }  
    public bool IsDeleted { get; set; }
}
