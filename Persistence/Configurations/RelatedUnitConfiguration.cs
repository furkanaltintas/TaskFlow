using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

class RelatedUnitConfiguration : IEntityTypeConfiguration<RelatedUnit>
{
    public void Configure(EntityTypeBuilder<RelatedUnit> builder)
    {
        builder.ToTable("RelatedUnits");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.Property(x => x.IsDeleted).IsRequired();

        builder.HasData(
            new RelatedUnit { Id = 1, Name = "Web", IsDeleted = false },
            new RelatedUnit { Id = 2, Name = "XRM", IsDeleted = false },
            new RelatedUnit { Id = 3, Name = "Donanım", IsDeleted = false },
            new RelatedUnit { Id = 4, Name = "Satış", IsDeleted = false },
            new RelatedUnit { Id = 5, Name = "IT", IsDeleted = false },
            new RelatedUnit { Id = 6, Name = "Finans", IsDeleted = false },
            new RelatedUnit { Id = 7, Name = "HR", IsDeleted = false },
            new RelatedUnit { Id = 8, Name = "Operasyon", IsDeleted = false },
            new RelatedUnit { Id = 9, Name = "Pazarlama", IsDeleted = false },
            new RelatedUnit { Id = 10, Name = "Müşteri Destek", IsDeleted = false }
        );
    }
}
