using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entitites;

public class AppRole : IdentityRole<int>
{
    public string? Description { get; set; }
}