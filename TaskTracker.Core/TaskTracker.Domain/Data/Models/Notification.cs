using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Domain;

public class Notification : BaseEntity
{
    public Guid TaskId { get; set; }
    [ForeignKey("TaskId")]
    public virtual DeskTask DeskTask  { get; set; }
    public string Text { get; set; }
    public bool Delivered { get; set; } 
    public DateTimeOffset? DeliveredTime { get; set; }
}