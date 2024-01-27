using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface IUserRepository
{
    Task<UserProfile> Add(UserProfile user);
    Task<IEnumerable<UserProfile>> GetAll();
    Task<UserProfile?> GetById(Guid id);
    Task<UserProfile?> Modify(UserProfile user);
    Task<UserProfile?> Delete(Guid id);
}