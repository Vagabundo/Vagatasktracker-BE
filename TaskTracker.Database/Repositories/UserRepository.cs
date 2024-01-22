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

    #region Create
    public async Task<User> Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
    #endregion

    #region Read
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _dbContext.Users
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await _dbContext.Users
        .AsNoTracking()
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();
    }
    #endregion

    #region Update
    public async Task<User?> Modify(User user)
    {
        var dbUser = await _dbContext.Users
        .Where(x => x.Id == user.Id && !x.IsDeleted)
        .FirstOrDefaultAsync();

        if (dbUser is not null)
        {
            dbUser.Name = user.Name;
            await _dbContext.SaveChangesAsync();
        }

        return dbUser;
    }
    #endregion

    #region Delete
    public async Task<User?> Delete(int id)
    {
        var user = await _dbContext.Users
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();

        if (user is not null)
        {
            user.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        return user;
    }

        /* why not */
    public async Task<User?> DeleteInTransaction(int id)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        User? user = null;
        try
        {
            // context.SaveChanges();
            // transaction.CreateSavepoint("BeforeMoreBlogs");
            user = await _dbContext.Users
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

            if (user is not null)
            {
                user.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }

            await _dbContext.SaveChangesAsync();
            transaction.Commit();
        }
        catch (Exception)
        {
            // If a failure occurred, we rollback to the savepoint and can continue the transaction
            //transaction.RollbackToSavepoint("BeforeMoreBlogs");

            // TODO: Handle failure, possibly retry inserting blogs
        }
        return user;
    }
    #endregion
}