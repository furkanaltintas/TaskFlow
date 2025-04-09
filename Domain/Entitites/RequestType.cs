using Domain.Common;

namespace Domain.Entitites;

public class RequestType : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}