using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Infrastructure.Persistence.Configurations;
public class TeamContextConfiguration : IEntityTypeConfiguration<Team>
{
  public void Configure(EntityTypeBuilder<Team> builder)
  {
    builder.ToTable("Team");

    builder.HasKey(team => team.Id);
    builder.Property(team => team.Id)
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

    builder.Property(team => team.Name)
      .HasColumnName("name");

    builder.Property(team => team.Description)
      .HasColumnName("description");

    builder.Property(team => team.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(team => team.UpdatedAt)
      .HasColumnName("updated_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(team => team.DeletedAt)
      .HasColumnName("deleted_at")
      .HasColumnType("timestamp with time zone");

    builder.HasMany(team => team.SuperHeroes)
      .WithMany(hero => hero.Teams)
      .UsingEntity<Dictionary<string, object>>(
        "TeamSuperHero",
        right => right.HasOne<SuperHero>()
          .WithMany()
          .HasForeignKey("super_hero_id")
          .OnDelete(DeleteBehavior.Cascade),
        left => left.HasOne<Team>()
          .WithMany()
          .HasForeignKey("team_id")
          .OnDelete(DeleteBehavior.Cascade),
        join =>
        {
          join.ToTable("TeamSuperHero");
          join.HasKey("team_id", "super_hero_id");
          join.Property<Guid>("team_id").HasColumnName("team_id");
          join.Property<Guid>("super_hero_id").HasColumnName("super_hero_id");
        });

    builder.HasMany(team => team.Villains)
      .WithMany(villain => villain.Teams)
      .UsingEntity<Dictionary<string, object>>(
        "TeamVillain",
        right => right.HasOne<Villain>()
          .WithMany()
          .HasForeignKey("villain_id")
          .OnDelete(DeleteBehavior.Cascade),
        left => left.HasOne<Team>()
          .WithMany()
          .HasForeignKey("team_id")
          .OnDelete(DeleteBehavior.Cascade),
        join =>
        {
          join.ToTable("TeamVillain");
          join.HasKey("team_id", "villain_id");
          join.Property<Guid>("team_id").HasColumnName("team_id");
          join.Property<Guid>("villain_id").HasColumnName("villain_id");
        });
  }
}
