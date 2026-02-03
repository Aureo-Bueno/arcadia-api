using ArcadiaApi.Application.Models;

namespace ArcadiaApi.Application.Interfaces;

public interface ICombatService
{
  Task<CombatResult> Fight(Guid superHeroId, Guid villainId);
}
