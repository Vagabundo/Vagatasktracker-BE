using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface IUserService
{
    Task<UserProfile> Add(UserProfile entity);
    Task<UserProfile> Delete(Guid id);
    Task<UserProfile> Get(Guid id);
    Task<IEnumerable<UserProfile>> GetAll();
    Task<UserProfile> Update(UserProfile entity);
}