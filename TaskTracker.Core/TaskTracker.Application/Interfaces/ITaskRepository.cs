using TaskTracker.Domain;

namespace TaskTracker.Application.Interfaces;

public interface ITaskRepository
{
    Task<DeskTask> Add(DeskTask task);
    Task<IEnumerable<DeskTask>> GetAll();
    Task<DeskTask?> GetById(int Id);
    Task<DeskTask?> Modify(DeskTask task);
    Task<DeskTask?> Delete(int id);
}