namespace ArcadiaApi.Entities;

public class Team : BaseEntity
{
  public string? Name { get; set; }

  public string? Description { get; set; }

  public ICollection<SuperHero>? SuperHeroes { get; set; }

  public ICollection<Villain>? Villains { get; set; }
}
