namespace TaskTracker.API.DTOs;

public class UserProfileDTO : BaseDTO
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string FamilyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}