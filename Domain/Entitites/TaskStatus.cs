using Domain.Common;

namespace Domain.Entitites;

public class TaskStatus : Entity // Talep durumlarını saklar
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; // Durum açıklaması
    public string? ColorCode { get; set; } // Durum renk kodu (isteğe bağlı)

    // Soft delete flag
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<AppTask> AppTasks { get; set; } = new List<AppTask>();
}


//public class TaskAttachment : Entity // Talebe eklenen dosyaları saklar
//{
//    public int AppTaskId { get; set; }
//    public string FileName { get; set; } = null!;
//    public string FilePath { get; set; } = null!;
//    public string Description { get; set; } = null!;
//    public DateTime CreatedAt { get; set; }
//    public AppTask AppTask { get; set; } = null!;
//}