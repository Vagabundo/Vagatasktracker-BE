using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class UserRepository : IUserRepository
{
    private ITaskTrackerContext _dbContext;

    public UserRepository(ITaskTrackerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Modify(User user)
    {
        throw new NotImplementedException();
    }
}
