using Domain.Common;

namespace Domain.Entitites;

// Tarihsel bilgiler ve durumlar
//public class TaskStatusInfo : Entity
//{
//    public int AppTaskId { get; set; }
//    public DateTime? CompletedAt { get; set; }
//    public DateTime? ClosedAt { get; set; }
//    public DateTime? DeletedAt { get; set; }
//    public DateTime? ExpectedCompletionDate { get; set; } // Tahmini tamamlanma tarihi
//    public bool IsCompleted { get; set; } = false;
//    public bool IsDeleted { get; set; } = false;

//    public List<AppTask> AppTasks { get; set; }
//}


//public class TaskAttachment : Entity // Talebe eklenen dosyaları saklar
//{
//    public int AppTaskId { get; set; }
//    public string FileName { get; set; } = null!;
//    public string FilePath { get; set; } = null!;
//    public string Description { get; set; } = null!;
//    public DateTime CreatedAt { get; set; }
//    public AppTask AppTask { get; set; } = null!;
//}