namespace TaskTracker.Domain;

public interface IEntity
{
    Guid Id { get; set; }
    bool IsDeleted { get; set; }
}
