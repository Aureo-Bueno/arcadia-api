using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Models;

public enum CombatOutcome
{
  HeroWins,
  VillainWins,
  Draw,
}

public class CombatResult
{
  public SuperHero Hero { get; init; } = default!;
  public Villain Villain { get; init; } = default!;
  public int HeroPowerLevel { get; init; }
  public int VillainPowerLevel { get; init; }
  public CombatOutcome Outcome { get; init; }
  public Guid? WinnerId { get; init; }
  public string? WinnerName { get; init; }
}
