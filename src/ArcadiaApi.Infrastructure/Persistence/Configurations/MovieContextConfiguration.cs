using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Infrastructure.Persistence.Configurations;
public class MovieContextConfiguration: IEntityTypeConfiguration<Movie>
{
  private static readonly DateTime SeedTimestamp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  private readonly Guid[] _ids;

  public MovieContextConfiguration(Guid[] ids)
  {
    _ids = ids;
  }

  public void Configure(EntityTypeBuilder<Movie> builder)
  {
    builder.ToTable("Movie");

    builder.HasKey(movie => movie.Id);
    builder.Property(movie => movie.Id)
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

    builder.Property(movie => movie.Title)
      .HasColumnName("title");

    builder.Property(movie => movie.Description)
      .HasColumnName("description");

    builder.Property(movie => movie.SuperHeroId)
      .HasColumnName("super_hero_id");

    builder.Property(movie => movie.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(movie => movie.UpdatedAt)
      .HasColumnName("updated_at")
      .HasColumnType("timestamp with time zone");

    builder.Property(movie => movie.DeletedAt)
      .HasColumnName("deleted_at")
      .HasColumnType("timestamp with time zone");

    builder.HasOne(movie => movie.SuperHero)
      .WithMany(hero => hero.Movies)
      .HasForeignKey(movie => movie.SuperHeroId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasData(
      new Movie {
        Id = Guid.Parse("ef2399b0-3292-4aa5-a157-e498d70c8786"),
        Title = "Superman",
        Description = "Superman is a fictional superhero. The character was created by writer Jerry Siegel and artist Joe Shuster, and first appeared in the comic book Action Comics #1 (cover-dated June 1938 and published April 18, 1938).",
        SuperHeroId = _ids[0],
        CreatedAt = SeedTimestamp,
        UpdatedAt = SeedTimestamp,
        DeletedAt = null,
      },
      new Movie {
        Id = Guid.Parse("a2db1d07-5491-4b22-bf67-417f079340bc"),
        Title = "Batman",
        Description = "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger,[2][3] and first appeared in Detective Comics #27 (May 1939).",
        SuperHeroId = _ids[1],
        CreatedAt = SeedTimestamp,
        UpdatedAt = SeedTimestamp,
        DeletedAt = null,
      }
    );
  } 
}
