using Microsoft.AspNetCore.Identity;

namespace Domain.Entitites;

public class AppUser : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpires { get; set; }

    public virtual ICollection<AppTask>? Tasks { get; set; }
}