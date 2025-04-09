using Domain.Common;

namespace Domain.Entitites;

public class TaskAssigmentInfo : Entity
{
    public int AppTaskId { get; set; }
    public string? AssignedTo { get; set; }
    public string? CompletedBy { get; set; }
    public string? ClosedBy { get; set; }
    public string? DeletedBy { get; set; }

    public AppTask? AppTask { get; set; }
}