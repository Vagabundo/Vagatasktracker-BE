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

    public async Task<UserProfile> Add(UserProfile entity)
    {
        return await _userRepository.Add(entity);
    }

    public async Task<UserProfile> Get(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<IEnumerable<UserProfile>> GetAll()
    {
        return await _userRepository.GetAll();
    }
    public async Task<UserProfile> Delete(Guid id)
    {
        return await _userRepository.Delete(id);
    }

    public async Task<UserProfile> Update(UserProfile entity)
    {
        return await _userRepository.Modify(entity);
    }
}