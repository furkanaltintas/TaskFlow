using Domain.Common;

namespace Domain.Entitites;

public class TaskComment : Entity
{
    public int AppTaskId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public AppTask? AppTask { get; set; }
}