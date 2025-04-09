using Domain.Common;

namespace Domain.Entitites;

public class AuditLog : Entity
{
    public string Action { get; set; } = string.Empty;
    public string PerformedBy { get; set; } = string.Empty;
    public DateTime PerformedAt { get; set; }
    public string Details { get; set; } = string.Empty;

    // Bağlantı tablosu (Opsiyonel): Hangi AppTask üzerinde işlem yapıldığını belirtebiliriz
    public int? AppTaskId { get; set; }
    public AppTask? AppTask { get; set; }
}