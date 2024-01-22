using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Database;

public class TaskRepository : ITaskRepository
{
    private ITaskTrackerContext _dbContext;
    public TaskRepository(ITaskTrackerContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region Create
    public async Task<DeskTask> Add(DeskTask task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();

        return task;
    }
    #endregion

    #region Read
    public async Task<IEnumerable<DeskTask>> GetAll()
    {
        return await _dbContext.Tasks
        .AsNoTracking()
        .ToListAsync();
    }
    #endregion

    public async Task<DeskTask?> GetById(int id)
    {
        return await _dbContext.Tasks
        .AsNoTracking()
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();
    }

    #region Update
    public async Task<DeskTask?> Modify(DeskTask task)
    {
        var dbTask = await _dbContext.Tasks
        .Where(x => x.Id == task.Id && !x.IsDeleted)
        .FirstOrDefaultAsync();

        if (dbTask is not null)
        {
            dbTask.Name = task.Name;
            dbTask.Description = task.Description;
            dbTask.DueTime = task.DueTime;

            await _dbContext.SaveChangesAsync();
        }

        return dbTask;
    }
    #endregion

    #region Delete
    public async Task<DeskTask?> Delete(int id)
    {
        var task = await _dbContext.Tasks
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();

        if (task is not null)
        {
            task.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        return task;
    }
    #endregion
}
