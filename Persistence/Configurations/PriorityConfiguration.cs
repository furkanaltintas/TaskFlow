using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
    public void Configure(EntityTypeBuilder<Priority> builder)
    {
        builder.ToTable("Priorities");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Definition).IsRequired().HasMaxLength(100);

        builder.HasData(
            new Priority { Id = 1, Definition = "High" },
            new Priority { Id = 2, Definition = "Medium" },
            new Priority { Id = 3, Definition = "Low" },
            new Priority { Id = 4, Definition = "Urgent" },
            new Priority { Id = 5, Definition = "Critical" },
            new Priority { Id = 6, Definition = "Normal" },
            new Priority { Id = 7, Definition = "Very High" },
            new Priority { Id = 8, Definition = "Low-Moderate" },
            new Priority { Id = 9, Definition = "Backlog" },
            new Priority { Id = 10, Definition = "Emergency" }
        );
    }
}