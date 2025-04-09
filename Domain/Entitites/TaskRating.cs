using Domain.Common;

namespace Domain.Entitites;

public class TaskRating : Entity
{
    public int AppTaskId { get; set; }
    public int Rating { get; set; } // 1-5 arası puanlama gibi
    public string? Comments { get; set; } // Kullanıcının değerlendirme yaparken girdiği yorum
    public DateTime CreatedAt { get; set; }

    public AppTask? AppTask { get; set; }
}