using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;

namespace TaskTracker.Application.Services;

public class TaskService : ITaskService
{
    private ITaskRepository _taskRepository;
    private INotificationRepository _notificationRepository;

    public TaskService (ITaskRepository taskRepository, INotificationRepository notificationRepository)
    {
        _taskRepository = taskRepository;
        _notificationRepository = notificationRepository;
    }

    public async Task<DeskTask> Add(DeskTask deskTask)
    {
        await _taskRepository.Add(deskTask);
        await _notificationRepository.Add(new Notification
        {
            TaskId = deskTask.Id,
            Text = deskTask.Description ?? deskTask.Name
        });

        return deskTask;
    }

    public async Task<IEnumerable<DeskTask>> GetAll()
    {
        return await _taskRepository.GetAll();
    }

    public async Task<DeskTask> Get(Guid id)
    {
        return await _taskRepository.GetById(id);
    }

    public async Task<DeskTask> Update(DeskTask deskTask)
    {
        throw new NotImplementedException();
    }

    public Task<DeskTask> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}