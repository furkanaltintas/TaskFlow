using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();

        builder.ToTable("Roles");

        builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

        builder.Property(u => u.Name).HasMaxLength(256);
        builder.Property(u => u.NormalizedName).HasMaxLength(256);

        builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);

        // Varsayılan rollerin eklenmesi
        builder.HasData(
            new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN", Description = "Administrator with full permissions", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 2, Name = "Supervisor", NormalizedName = "SUPERVISOR", Description = "Role with supervisory access", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 3, Name = "Support Specialist", NormalizedName = "SUPPORT SPECIALIST", Description = "Role for support team members", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 4, Name = "End User", NormalizedName = "END USER", Description = "General user role", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 5, Name = "Manager", NormalizedName = "MANAGER", Description = "Role for managers", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 6, Name = "Team Lead", NormalizedName = "TEAM LEAD", Description = "Role for team leaders", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 7, Name = "Technician", NormalizedName = "TECHNICIAN", Description = "Role for technical staff", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 8, Name = "Customer", NormalizedName = "CUSTOMER", Description = "Role for customers", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 9, Name = "HR", NormalizedName = "HR", Description = "Role for HR department", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new AppRole { Id = 10, Name = "IT Support", NormalizedName = "IT SUPPORT", Description = "Role for IT support staff", ConcurrencyStamp = Guid.NewGuid().ToString() }
        );
    }
}