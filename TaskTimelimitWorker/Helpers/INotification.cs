namespace TaskTimelimit.Worker;

public interface INotification
{
    Task SendNotification(DateTime currentTime);
}