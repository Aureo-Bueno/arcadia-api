using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Api.GraphQL;

public class Mutation
{
  private readonly ISuperHeroService _superHeroService;
  private readonly IPowerService _powerService;
  private readonly IVillainService _villainService;
  private readonly ITeamService _teamService;

  public Mutation(
    ISuperHeroService superHeroService,
    IPowerService powerService,
    IVillainService villainService,
    ITeamService teamService)
  {
    _superHeroService = superHeroService;
    _powerService = powerService;
    _villainService = villainService;
    _teamService = teamService;
  }
  
  public Task<SuperHero> AddSuperHero(string name, string description, int? powerLevel) =>
    _superHeroService.AddSuperHero(name, description, powerLevel);

  public Task<SuperHero> UpdateSuperHero(Guid id, string? name, string? description, int? powerLevel) =>
    _superHeroService.UpdateSuperHero(id, name, description, powerLevel);
  
  public Task<Power> AddPower(
    Guid superHeroId,
    string? description,
    string? superPower) => _powerService.AddPower(superHeroId, description, superPower);
  
  public Task<Power> UpdatePower(
    Guid id,
    Guid? superHeroId,
    string? description,
    string? superPower) => _powerService.UpdatePower(id, superHeroId, description, superPower);

  public Task<Villain> AddVillain(string name, string? description, int? powerLevel) =>
    _villainService.AddVillain(name, description, powerLevel);

  public Task<Villain> UpdateVillain(Guid id, string? name, string? description, int? powerLevel) =>
    _villainService.UpdateVillain(id, name, description, powerLevel);

  public Task<Team> AddTeam(
    string name,
    string? description,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds) =>
    _teamService.AddTeam(name, description, superHeroIds, villainIds);

  public Task<Team> UpdateTeam(
    Guid id,
    string? name,
    string? description,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds) =>
    _teamService.UpdateTeam(id, name, description, superHeroIds, villainIds);

  public Task<Team> AddTeamMembers(
    Guid id,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds) =>
    _teamService.AddTeamMembers(id, superHeroIds, villainIds);

  public Task<Team> RemoveTeamMembers(
    Guid id,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds) =>
    _teamService.RemoveTeamMembers(id, superHeroIds, villainIds);
}
