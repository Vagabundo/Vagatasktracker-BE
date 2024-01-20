using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Application.Services;

public class TaskService : ITaskService
{
    private ITaskRepository _taskRepository;

    public TaskService (ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<DeskTask> Add(DeskTask deskTask)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<DeskTask>> GetAll()
    {
        return await _taskRepository.GetAll();
    }

    public async Task<DeskTask> Get(int id)
    {
        return await _taskRepository.GetById(id);
    }

    public async Task<DeskTask> Update(DeskTask deskTask)
    {
        throw new NotImplementedException();
    }

    public Task<DeskTask> Delete(int id)
    {
        throw new NotImplementedException();
    }
}