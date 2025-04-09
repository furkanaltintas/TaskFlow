using Domain.Common;

namespace Domain.Entitites;

public class Priority : Entity
{
    public string Definition { get; set; } = string.Empty;

    public virtual ICollection<AppTask>? Tasks { get; set; }
}