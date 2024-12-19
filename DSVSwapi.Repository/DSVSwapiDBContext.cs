using DSVSwapi.Repository.Model;

namespace DSVSwapi.Repository;

using Microsoft.EntityFrameworkCore;

public class DSVSwapiDBContext : DbContext
{
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Resident> Residents { get; set; }

    public DSVSwapiDBContext(DbContextOptions<DSVSwapiDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Planet>().HasMany(p => p.Residents)
            .WithOne(r => r.Planet).HasForeignKey(r => r.PlanetId);
    }
}