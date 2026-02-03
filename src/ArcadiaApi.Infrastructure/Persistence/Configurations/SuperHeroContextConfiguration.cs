using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Infrastructure.Persistence.Configurations;
public class SuperHeroContextConfiguration : IEntityTypeConfiguration<SuperHero>
{
  private static readonly DateTime SeedTimestamp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  private readonly Guid[] _ids;

  public SuperHeroContextConfiguration(Guid[] ids)
  {
    _ids = ids;
  }

  public void Configure(EntityTypeBuilder<SuperHero> builder)
  {
    builder.ToTable("SuperHero");

    builder.HasKey(hero => hero.Id);
    builder.Property(hero => hero.Id)
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

    builder.Property(hero => hero.Name)
      .HasColumnName("name");

    builder.Property(hero => hero.Description)
      .HasColumnName("description");

    builder.Property(hero => hero.PowerLevel)
      .HasColumnName("power_level")
      .HasDefaultValue(0);

    builder.Property(hero => hero.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(hero => hero.UpdatedAt)
      .HasColumnName("updated_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(hero => hero.DeletedAt)
      .HasColumnName("deleted_at")
      .HasColumnType("timestamp with time zone");

    builder.HasData(
      new SuperHero {
        Id = _ids[0],
        Name = "Superman",
        Description = "Superman is a fictional superhero. The character was created by writer Jerry Siegel and artist Joe Shuster, and first appeared in the comic book Action Comics #1 (cover-dated June 1938 and published April 18, 1938).",
        PowerLevel = 95,
        CreatedAt = SeedTimestamp,
        UpdatedAt = SeedTimestamp,
        DeletedAt = null,
      },
      new SuperHero {
        Id = _ids[1],
        Name = "Batman",
        Description = "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger,[2][3] and first appeared in Detective Comics #27 (May 1939).",
        PowerLevel = 85,
      }
    );
  }
        
}
