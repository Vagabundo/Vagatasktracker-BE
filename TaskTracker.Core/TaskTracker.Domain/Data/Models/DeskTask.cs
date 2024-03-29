using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskTracker.Domain;

public class DeskTask : BaseEntity
{  
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual IdentityUser<Guid> User  { get; set; }
    public DateTimeOffset? DueTime { get; set; }
}