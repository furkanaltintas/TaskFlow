using Domain.Common;

namespace Domain.Entitites;

public class AppTask : Entity
{
    public int UserId { get; set; }
    public int TaskStatusId { get; set; }
    public int PriorityId { get; set; }
    public int RequestTypeId { get; set; }
    public int RelatedUnitId { get; set; }

    public string TaskCode { get; set; } = string.Empty; // Örnek: #BT-250723001
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }  // Zorunlu
    public DateTime? UpdatedAt { get; set; } // Son değişiklik
    public DateTime? CompletedAt { get; set; } // Tamamlanma zamanı
    public DateTime? ClosedAt { get; set; } // Kapanma zamanı
    public DateTime? DeletedAt { get; set; } // Silinme zamanı
    public DateTime? ExpectedCompletionDate { get; set; } // SLA hedefi
    public bool IsCompleted { get; set; } = false;
    public bool IsDeleted { get; set; } = false;


    // Navigation Properties
    public virtual AppUser User { get; set; } = null!;
    public virtual Priority? Priority { get; set; }
    public virtual RequestType? RequestType { get; set; }
    public virtual RelatedUnit? RelatedUnit { get; set; }
    public virtual TaskStatus? TaskStatus { get; set; }


    public virtual ICollection<TaskReport>? TaskReports { get; set; }
    public virtual ICollection<TaskRating>? TaskRatings { get; set; }
    public virtual TaskAssigmentInfo? AssigmentInfo { get; set; }
    public virtual TaskMedia? TaskMedia { get; set; }
}