using Domain.Entitites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace Persistence.Contexts;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<AppTask> AppTasks { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<RelatedUnit> RelatedUnits { get; set; }
    public DbSet<RequestType> RequestTypes { get; set; }
    public DbSet<TaskAssigmentInfo> TaskAssigmentInfos { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }
    public DbSet<TaskHistory> TaskHistories { get; set; }
    public DbSet<TaskMedia> TaskMedias { get; set; }
    public DbSet<TaskRating> TaskRatings { get; set; }
    public DbSet<TaskReport> TaskReports { get; set; }
    public DbSet<Domain.Entitites.TaskStatus> TaskStatuses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Ignore<IdentityUserLogin<int>>();
        modelBuilder.Ignore<IdentityRoleClaim<int>>();
        modelBuilder.Ignore<IdentityUserToken<int>>();
        modelBuilder.Ignore<IdentityUserClaim<int>>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings
        .Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}