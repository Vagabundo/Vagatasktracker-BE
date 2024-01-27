using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskTracker.Domain;

public class UserProfile
{  
    [Key]
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual IdentityUser<Guid> User  { get; set; }
    public string Name { get; set; }
    public string FamilyName { get; set; }
    public bool IsDeleted { get; set; }
}
