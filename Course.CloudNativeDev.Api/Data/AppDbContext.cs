using Course.CloudNativeDev.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course.CloudNativeDev.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Attendee> Attendee { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<JobRole> JobRoles { get; set; }
    public DbSet<ReferalSource> ReferalSources { get; set; }
}