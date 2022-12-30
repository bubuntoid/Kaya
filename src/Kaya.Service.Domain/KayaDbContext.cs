using Kaya.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kaya.Service.Domain;

public class KayaDbContext : DbContext
{
    private readonly IDatabaseSettings databaseSettings;
        
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<SystemEventTagSetting> SystemEventTagSettings { get; set; }

    public KayaDbContext(IDatabaseSettings databaseSettings)
    {
        this.databaseSettings = databaseSettings;
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(databaseSettings.ConnectionString).UseCamelCaseNamingConvention();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KayaDbContext).Assembly);
        modelBuilder.HasDefaultSchema("public");   
        base.OnModelCreating(modelBuilder);
    }
}