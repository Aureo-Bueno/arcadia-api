namespace ArcadiaApi.Entities;
public class Power : BaseEntity
{
  public string? SuperPower { get; set; }

  public string? Description { get; set; }

  public Guid SuperHeroId { get; set; }
  public SuperHero? SuperHero { get; set; }
}
