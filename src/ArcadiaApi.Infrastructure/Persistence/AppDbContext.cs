using Microsoft.EntityFrameworkCore;
using ArcadiaApi.Infrastructure.Interceptors;
using ArcadiaApi.Infrastructure.Persistence.Configurations;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Infrastructure.Persistence;
public class AppDbContext : DbContext 
{
  private static readonly Guid[] SeedHeroIds = new[]
  {
    Guid.Parse("253a3137-0404-4274-a15f-bcf608ce8a71"),
    Guid.Parse("2968f15c-fa74-4058-b790-3feec7934faf"),
  };
  private static readonly Guid[] SeedVillainIds = new[]
  {
    Guid.Parse("1d7b30f3-72d4-43b1-a9f9-1630f4fd63be"),
    Guid.Parse("6e3c7e69-6c1d-4b04-9de3-3c62d0a31622"),
  };

  private readonly SlowQueryInterceptor _slowQueryInterceptor;
  public AppDbContext(DbContextOptions<AppDbContext> options, SlowQueryInterceptor slowQueryInterceptor)
    : base(options)
  {
    _slowQueryInterceptor = slowQueryInterceptor;
  }
  
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfiguration(new SuperHeroContextConfiguration(SeedHeroIds));
    builder.ApplyConfiguration(new PowerContextConfiguration(SeedHeroIds));
    builder.ApplyConfiguration(new MovieContextConfiguration(SeedHeroIds));
    builder.ApplyConfiguration(new VillainContextConfiguration(SeedVillainIds));
    builder.ApplyConfiguration(new TeamContextConfiguration());
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(_slowQueryInterceptor);
  }

  public override int SaveChanges()
  {
    UpdateTimestamps();
    return base.SaveChanges();
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    UpdateTimestamps();
    return base.SaveChangesAsync(cancellationToken);
  }

  private void UpdateTimestamps()
  {
    var now = DateTime.UtcNow;
    foreach (var entry in ChangeTracker.Entries<BaseEntity>())
    {
      if (entry.State == EntityState.Added)
      {
        entry.Entity.CreatedAt = now;
        entry.Entity.UpdatedAt = now;
      }
      else if (entry.State == EntityState.Modified)
      {
        entry.Entity.UpdatedAt = now;
      }
    }
  }
}
