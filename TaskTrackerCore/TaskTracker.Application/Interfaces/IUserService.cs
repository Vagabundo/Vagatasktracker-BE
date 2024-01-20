using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface IUserService
{
    Task<User> Add(User entity);
    Task<User> Delete(int id);
    Task<User> Get(int Id);
    Task<IEnumerable<User>> GetAll();
    Task<User> Update(User entity);
}