using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class UserRepository : IUserRepository
{
    private TaskTrackerContextBase _dbContext;

    public UserRepository(TaskTrackerContextBase dbContext)
    {
        _dbContext = dbContext;
    }

    #region Create
    public async Task<UserProfile> Add(UserProfile user)
    {
        await _dbContext.UserProfiles.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
    #endregion

    #region Read
    public async Task<IEnumerable<UserProfile>> GetAll()
    {
        return await _dbContext.UserProfiles
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<UserProfile?> GetById(Guid id)
    {
        return await _dbContext.UserProfiles
        .AsNoTracking()
        .Where(x => x.UserId == id)
        .FirstOrDefaultAsync();
    }
    #endregion

    #region Update
    public async Task<UserProfile?> Modify(UserProfile profile)
    {
        var dbUser = await _dbContext.UserProfiles
        .Where(x => x.UserId == profile.UserId && !x.IsDeleted)
        .FirstOrDefaultAsync();

        if (dbUser is not null)
        {
            dbUser.Name = profile.Name;
            await _dbContext.SaveChangesAsync();
        }

        return dbUser;
    }
    #endregion

    #region Delete
    public async Task<UserProfile?> Delete(Guid id)
    {
        var user = await _dbContext.UserProfiles
        .Where(x => x.UserId == id)
        .FirstOrDefaultAsync();

        if (user is not null)
        {
            user.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        return user;
    }

        /* why not */
    public async Task<UserProfile?> DeleteInTransaction(Guid id)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        UserProfile? user = null;
        try
        {
            // context.SaveChanges();
            // transaction.CreateSavepoint("BeforeMoreBlogs");
            user = await _dbContext.UserProfiles
            .Where(x => x.UserId == id)
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