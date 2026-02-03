using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Infrastructure.Persistence.Configurations;
public class PowerContextConfiguration : IEntityTypeConfiguration<Power>
{
  private static readonly DateTime SeedTimestamp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  private readonly Guid[] _ids;

  public PowerContextConfiguration(Guid[] ids)
  {
    _ids = ids;
  }

  public void Configure(EntityTypeBuilder<Power> builder)
  {
    builder.ToTable("Power");

    builder.HasKey(power => power.Id);
    builder.Property(power => power.Id)
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

    builder.Property(power => power.SuperPower)
      .HasColumnName("super_power");

    builder.Property(power => power.Description)
      .HasColumnName("description");

    builder.Property(power => power.SuperHeroId)
      .HasColumnName("super_hero_id");

    builder.Property(power => power.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(power => power.UpdatedAt)
      .HasColumnName("updated_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(power => power.DeletedAt)
      .HasColumnName("deleted_at")
      .HasColumnType("timestamp with time zone");

    builder.HasOne(power => power.SuperHero)
      .WithMany(hero => hero.Powers)
      .HasForeignKey(power => power.SuperHeroId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasData(
      new Power
      {
        Id = Guid.Parse("1c6c0a5d-dbb3-489d-9a9c-d851673ccbbf"),
        SuperPower = "Superhuman strength, speed, stamina and durability",
        Description = "Superman's powers include incredible strength, the ability to fly, and invulnerability.",
        SuperHeroId = _ids[0],
        CreatedAt = SeedTimestamp,
        UpdatedAt = SeedTimestamp,
        DeletedAt = null,
      },
      new Power
      {
        Id = Guid.Parse("fce10a99-29d4-408f-962e-78b079ca69c8"),
        SuperPower = "Genius-level intellect",
        Description = "Batman's primary character traits can be summarized as \"wealthy, physical prowess, deductive abilities and obsession\".",
        SuperHeroId = _ids[1],
        CreatedAt = SeedTimestamp,
        UpdatedAt = SeedTimestamp,
        DeletedAt = null,
      }
    );
  }
        
}
