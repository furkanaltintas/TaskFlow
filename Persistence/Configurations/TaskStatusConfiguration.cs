using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

class TaskStatusConfiguration : IEntityTypeConfiguration<Domain.Entitites.TaskStatus>
{
    public void Configure(EntityTypeBuilder<Domain.Entitites.TaskStatus> builder)
    {
        builder.ToTable("AppTaskStatuses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Description).HasMaxLength(100);

        builder.Property(x => x.IsDeleted).IsRequired();

        builder.HasData(
            new Domain.Entitites.TaskStatus { Id = 1, Name = "Yeni", Description = "New", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 2, Name = "Devam Ediyor", Description = "In Progress", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 3, Name = "Tamamlandı", Description = "Completed", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 4, Name = "Kapatıldı", Description = "Closed", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 5, Name = "Beklemede", Description = "On Hold", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 6, Name = "İptal Edildi", Description = "Cancelled", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 7, Name = "Tekrar Açıldı", Description = "Reopened", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 8, Name = "Onay Bekliyor", Description = "Awaiting Approval", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 9, Name = "İnceleniyor", Description = "Under Investigation", IsDeleted = false },
            new Domain.Entitites.TaskStatus { Id = 10, Name = "Beklemede", Description = "Pending", IsDeleted = false }
        );
    }
}