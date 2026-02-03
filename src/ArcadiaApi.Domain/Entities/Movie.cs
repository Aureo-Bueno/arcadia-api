namespace ArcadiaApi.Entities;
public class Movie : BaseEntity
{
  public string? Title { get; set; }

  public string? Description { get; set; }

  public Guid SuperHeroId { get; set; }
  public SuperHero? SuperHero { get; set; }
}
