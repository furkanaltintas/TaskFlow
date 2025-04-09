using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

class AppUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.ToTable("UserRoles");

        builder.HasData(
            new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1 
            }
        );
    }
}