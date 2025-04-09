using Domain.Common;

namespace Domain.Entitites;

// Dosyalar burada tutulacak
public class TaskMedia : Entity
{
    public int AppTaskId { get; set; }
    public string? ImagePath1 { get; set; }
    public string? ImagePath2 { get; set; }
    public string? ImagePath3 { get; set; }
    public string? ImagePath4 { get; set; }
    public string? DocumentPath { get; set; }

    public AppTask? AppTask { get; set; }
}