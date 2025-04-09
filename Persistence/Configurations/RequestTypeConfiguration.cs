using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

class RequestTypeConfiguration : IEntityTypeConfiguration<RequestType>
{
    public void Configure(EntityTypeBuilder<RequestType> builder)
    {
        builder.ToTable("RequestTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.Property(x => x.IsDeleted).IsRequired();

        builder.HasData(
            new RequestType { Id = 1, Name = "Arıza", IsDeleted = false },
            new RequestType { Id = 2, Name = "Hizmet Talebi", IsDeleted = false },
            new RequestType { Id = 3, Name = "Problem", IsDeleted = false },
            new RequestType { Id = 4, Name = "Değişiklik Talebi", IsDeleted = false },
            new RequestType { Id = 5, Name = "Maintenance", IsDeleted = false },
            new RequestType { Id = 6, Name = "Complaint", IsDeleted = false },
            new RequestType { Id = 7, Name = "Bug", IsDeleted = false },
            new RequestType { Id = 8, Name = "Feature Request", IsDeleted = false },
            new RequestType { Id = 9, Name = "Inquiry", IsDeleted = false },
            new RequestType { Id = 10, Name = "Support", IsDeleted = false }
        );
    }
}
