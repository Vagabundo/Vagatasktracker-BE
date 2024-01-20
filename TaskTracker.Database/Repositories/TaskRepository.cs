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

    public async Task<DeskTask> Add(DeskTask task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();

        return task;
    }

    public async Task<IEnumerable<DeskTask>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<DeskTask> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<DeskTask> Modify(Task task)
    {
        throw new NotImplementedException();
    }

    public async Task<DeskTask> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
