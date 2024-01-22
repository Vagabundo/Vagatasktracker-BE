namespace TaskTracker.API.DTOs;

public class NotificationDTO : BaseDTO
{
    public int TaskId { get; set; }
    public string Text { get; set; }
    public bool Delivered { get; set; } 
    public DateTimeOffset? DeliveredTime { get; set; }
}