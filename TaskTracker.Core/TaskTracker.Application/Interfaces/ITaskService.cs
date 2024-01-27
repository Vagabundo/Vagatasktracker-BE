using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface ITaskService
{
    Task<DeskTask> Add(DeskTask deskTask);
    Task<IEnumerable<DeskTask>> GetAll();
    Task<DeskTask> Get(Guid id);
    Task<DeskTask> Update(DeskTask deskTask);
    Task<DeskTask> Delete(Guid id);
}