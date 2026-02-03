namespace ArcadiaApi.Entities;

public class Villain : BaseEntity
{
  public string? Name { get; set; }

  public string? Description { get; set; }

  public int PowerLevel { get; set; }

  public ICollection<Team>? Teams { get; set; }
}
