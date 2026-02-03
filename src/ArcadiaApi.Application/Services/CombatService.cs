using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Application.Models;
using ArcadiaApi.Entities;
using Microsoft.Extensions.Logging;

namespace ArcadiaApi.Application.Services;

public class CombatService : ICombatService
{
  private readonly ISuperHeroService _superHeroService;
  private readonly IVillainService _villainService;
  private readonly ILogger<CombatService> _logger;

  public CombatService(
    ISuperHeroService superHeroService,
    IVillainService villainService,
    ILogger<CombatService> logger)
  {
    _superHeroService = superHeroService;
    _villainService = villainService;
    _logger = logger;
  }

  public async Task<CombatResult> Fight(Guid superHeroId, Guid villainId)
  {
    _logger.LogInformation("Combat started. HeroId={HeroId} VillainId={VillainId}", superHeroId, villainId);

    SuperHero hero = await _superHeroService.FindSuperHeroById(superHeroId)
                     ?? throw new Exception("SuperHero not found");
    Villain villain = await _villainService.FindVillainById(villainId)
                      ?? throw new Exception("Villain not found");

    var outcome = ResolveOutcome(hero.PowerLevel, villain.PowerLevel);

    Guid? winnerId = null;
    string? winnerName = null;

    if (outcome == CombatOutcome.HeroWins)
    {
      winnerId = hero.Id;
      winnerName = hero.Name;
    }
    else if (outcome == CombatOutcome.VillainWins)
    {
      winnerId = villain.Id;
      winnerName = villain.Name;
    }

    var result = new CombatResult
    {
      Hero = hero,
      Villain = villain,
      HeroPowerLevel = hero.PowerLevel,
      VillainPowerLevel = villain.PowerLevel,
      Outcome = outcome,
      WinnerId = winnerId,
      WinnerName = winnerName,
    };

    _logger.LogInformation(
      "Combat finished. Outcome={Outcome} WinnerId={WinnerId}",
      result.Outcome,
      result.WinnerId);

    return result;
  }

  private static CombatOutcome ResolveOutcome(int heroPowerLevel, int villainPowerLevel)
  {
    if (heroPowerLevel == villainPowerLevel) return CombatOutcome.Draw;
    return heroPowerLevel > villainPowerLevel
      ? CombatOutcome.HeroWins
      : CombatOutcome.VillainWins;
  }
}
