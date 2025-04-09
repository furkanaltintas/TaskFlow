using Domain.Common;

namespace Domain.Entitites;

public class TaskHistory : Entity
{
    public int AppTaskId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string ChangeBy { get; set; } = string.Empty;
    public DateTime ChagedAt { get; set; }

    public AppTask? AppTask { get; set; }
}