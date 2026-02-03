using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Infrastructure.Persistence.Configurations;
public class VillainContextConfiguration : IEntityTypeConfiguration<Villain>
{
  private static readonly DateTime SeedTimestamp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  private readonly Guid[] _ids;

  public VillainContextConfiguration(Guid[] ids)
  {
    _ids = ids;
  }

  public void Configure(EntityTypeBuilder<Villain> builder)
  {
    builder.ToTable("Villain");

    builder.HasKey(villain => villain.Id);
    builder.Property(villain => villain.Id)
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

    builder.Property(villain => villain.Name)
      .HasColumnName("name");

    builder.Property(villain => villain.Description)
      .HasColumnName("description");

    builder.Property(villain => villain.PowerLevel)
      .HasColumnName("power_level")
      .HasDefaultValue(0);

    builder.Property(villain => villain.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(villain => villain.UpdatedAt)
      .HasColumnName("updated_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(villain => villain.DeletedAt)
      .HasColumnName("deleted_at")
      .HasColumnType("timestamp with time zone");

    builder.HasData(
      new Villain
      {
        Id = _ids[0],
        Name = "Joker",
        Description = "A chaotic criminal mastermind and Batman's most infamous foe.",
        PowerLevel = 80,
        CreatedAt = SeedTimestamp,
        UpdatedAt = SeedTimestamp,
        DeletedAt = null,
      },
      new Villain
      {
        Id = _ids[1],
        Name = "Lex Luthor",
        Description = "A genius industrialist and Superman's most dangerous rival.",
        PowerLevel = 88,
        CreatedAt = SeedTimestamp,
        UpdatedAt = SeedTimestamp,
        DeletedAt = null,
      }
    );
  }
}
