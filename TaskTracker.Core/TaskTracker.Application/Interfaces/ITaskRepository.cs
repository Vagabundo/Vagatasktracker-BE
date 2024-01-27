using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface ITaskRepository
{
    Task<DeskTask> Add(DeskTask task);
    Task<IEnumerable<DeskTask>> GetAll();
    Task<DeskTask?> GetById(Guid id);
    Task<DeskTask?> Modify(DeskTask task);
    Task<DeskTask?> Delete(Guid id);
}