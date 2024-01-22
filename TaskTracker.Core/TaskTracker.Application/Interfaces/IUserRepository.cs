using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface IUserRepository
{
    Task<User> Add(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<User?> Modify(User user);
    Task<User?> Delete(int id);
}