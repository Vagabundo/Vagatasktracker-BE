using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Application.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService (IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Add(User entity)
    {
        return await _userRepository.Add(entity);
    }

    public async Task<User> Get(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }
    public async Task<User> Delete(int id)
    {
        return await _userRepository.Delete(id);
    }

    public async Task<User> Update(User entity)
    {
        return await _userRepository.Modify(entity);
    }
}