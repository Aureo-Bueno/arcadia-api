namespace ArcadiaApi.Entities;
public class SuperHero : BaseEntity
{
  public string? Name { get; set; }

  public string? Description { get; set; }

  public int PowerLevel { get; set; }

  public ICollection<Power>? Powers { get; set; }

  public ICollection<Movie>? Movies { get; set; }

  public ICollection<Team>? Teams { get; set; }
}
