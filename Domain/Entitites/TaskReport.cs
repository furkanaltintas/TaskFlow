using Domain.Common;

namespace Domain.Entitites;

public class TaskReport : Entity
{
    public int AppTaskId { get; set; }
    public string ReportContent { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public AppTask? AppTask { get; set; }
}