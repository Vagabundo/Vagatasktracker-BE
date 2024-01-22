using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Domain;

public class DeskTask : BaseEntity
{  
    public string Name { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User  { get; set; }
    public DateTimeOffset? DueTime { get; set; }
}