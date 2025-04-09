using Domain.Entitites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
        builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

        builder.ToTable("Users");

        builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        builder.Property(u => u.UserName).HasMaxLength(50);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(50);
        builder.Property(u => u.Email).HasMaxLength(100);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(100);

        builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();


        builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.LastName).HasMaxLength(200).IsRequired(true);

        builder.HasIndex(x => x.UserName).IsUnique(true);
        builder.Property(x => x.UserName).HasMaxLength(200);
        builder.Property(x => x.UserName).IsRequired(true);

        builder.Property(x => x.RefreshToken).HasMaxLength(500);
        builder.Property(x => x.RefreshTokenExpires).HasColumnType("datetime2");

        builder.Property(x => x.Email).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.NormalizedEmail).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.NormalizedUserName).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.LockoutEnabled).IsRequired(true);
        builder.Property(x => x.ConcurrencyStamp).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.SecurityStamp).HasMaxLength(200).IsRequired(true);


        AppUser user = new AppUser
        {
            Id = 1,
            FirstName = "Ahmet",
            LastName = "Yılmaz",
            UserName = "ahmet.yilmaz",
            PasswordHash = "Password123!", // Gerçek uygulamada hashlenmiş şifre kullanılmalıdır
            RefreshToken = "sample-refresh-token",
            RefreshTokenExpires = DateTime.UtcNow.AddDays(30),
            Email = "ahmet.yilmaz@example.com",
            NormalizedEmail = "AHMET.YILMAZ@EXAMPLE.COM",
            NormalizedUserName = "AHMET.YILMAZ",
            LockoutEnabled = false,
            ConcurrencyStamp = "12345678",
            SecurityStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true
        };
        user.PasswordHash = CreatePasswordHash(user, "Password123!"); // Hashlenmiş şifre oluşturma

        builder.HasData(user);
    }

    private string CreatePasswordHash(AppUser user, string password)
    {
        PasswordHasher<AppUser> passwordHasher = new();
        return passwordHasher.HashPassword(user, password);
    }
}