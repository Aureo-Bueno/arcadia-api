using Microsoft.Extensions.Logging;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Services;

public class TeamService : ITeamService
{
  private readonly ITeamRepository _repository;
  private readonly ILogger<TeamService> _logger;
  private readonly ISuperHeroService _superHeroService;
  private readonly IVillainService _villainService;

  public TeamService(
    ITeamRepository repository,
    ILogger<TeamService> logger,
    ISuperHeroService superHeroService,
    IVillainService villainService)
  {
    _repository = repository;
    _logger = logger;
    _superHeroService = superHeroService;
    _villainService = villainService;
  }

  public IQueryable<Team> Query() => _repository.Query();

  public async Task<Team> AddTeam(
    string name,
    string? description,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds)
  {
    Team team = new()
    {
      Name = name,
      Description = description,
    };

    if (superHeroIds is not null && superHeroIds.Count > 0)
      team.SuperHeroes = await ResolveHeroes(superHeroIds);

    if (villainIds is not null && villainIds.Count > 0)
      team.Villains = await ResolveVillains(villainIds);

    await _repository.AddAsync(team);
    await _repository.SaveChangesAsync();

    _logger.LogInformation("Added Team {Name}", name);
    return team;
  }

  public async Task<Team> UpdateTeam(
    Guid id,
    string? name,
    string? description,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds)
  {
    var team = await RequireTeam(id);

    if (name is not null) team.Name = name;
    if (description is not null) team.Description = description;

    if (superHeroIds is not null)
      team.SuperHeroes = await ResolveHeroes(superHeroIds);

    if (villainIds is not null)
      team.Villains = await ResolveVillains(villainIds);

    await _repository.SaveChangesAsync();
    _logger.LogInformation("Updated Team {Id}", team.Id);
    return team;
  }

  public async Task<Team> AddTeamMembers(
    Guid id,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds)
  {
    var team = await RequireTeam(id);

    if (superHeroIds is not null && superHeroIds.Count > 0)
    {
      var heroes = await ResolveHeroes(superHeroIds);
      team.SuperHeroes ??= new List<SuperHero>();
      HashSet<Guid> existingHeroIds = new();
      foreach (var hero in team.SuperHeroes)
        existingHeroIds.Add(hero.Id);

      foreach (var hero in heroes)
      {
        if (existingHeroIds.Add(hero.Id))
          team.SuperHeroes.Add(hero);
      }
    }

    if (villainIds is not null && villainIds.Count > 0)
    {
      var villains = await ResolveVillains(villainIds);
      team.Villains ??= new List<Villain>();
      HashSet<Guid> existingVillainIds = new();
      foreach (var villain in team.Villains)
        existingVillainIds.Add(villain.Id);

      foreach (var villain in villains)
      {
        if (existingVillainIds.Add(villain.Id))
          team.Villains.Add(villain);
      }
    }

    await _repository.SaveChangesAsync();
    _logger.LogInformation("Added members to Team {Id}", team.Id);
    return team;
  }

  public async Task<Team> RemoveTeamMembers(
    Guid id,
    IReadOnlyList<Guid>? superHeroIds,
    IReadOnlyList<Guid>? villainIds)
  {
    var team = await RequireTeam(id);

    if (superHeroIds is not null && superHeroIds.Count > 0 && team.SuperHeroes is not null)
    {
      HashSet<Guid> removeHeroIds = new(superHeroIds);
      List<SuperHero> toRemove = new();
      foreach (var hero in team.SuperHeroes)
      {
        if (removeHeroIds.Contains(hero.Id))
          toRemove.Add(hero);
      }

      foreach (var hero in toRemove)
        team.SuperHeroes.Remove(hero);
    }

    if (villainIds is not null && villainIds.Count > 0 && team.Villains is not null)
    {
      HashSet<Guid> removeVillainIds = new(villainIds);
      List<Villain> toRemove = new();
      foreach (var villain in team.Villains)
      {
        if (removeVillainIds.Contains(villain.Id))
          toRemove.Add(villain);
      }

      foreach (var villain in toRemove)
        team.Villains.Remove(villain);
    }

    await _repository.SaveChangesAsync();
    _logger.LogInformation("Removed members from Team {Id}", team.Id);
    return team;
  }

  public async Task<Team?> FindTeamById(Guid? id)
  {
    if (id is null)
      throw new ArgumentNullException(nameof(id), "Team ID cannot be null.");

    return await _repository.FindByIdAsync(id.Value)
           ?? throw new System.Collections.Generic.KeyNotFoundException($"Team with id {id} not found.");
  }

  private async Task<Team> RequireTeam(Guid id)
  {
    var team = await _repository.FindByIdAsync(id);
    if (team is null)
    {
      _logger.LogError("Team {Id} not found", id);
      throw new Exception("Team not found");
    }

    return team;
  }

  private async Task<List<SuperHero>> ResolveHeroes(IReadOnlyList<Guid> heroIds)
  {
    List<SuperHero> heroes = new();

    foreach (var heroId in heroIds)
    {
      if (heroId == Guid.Empty) continue;
      var hero = await _superHeroService.FindSuperHeroById(heroId);
      if (hero is not null) heroes.Add(hero);
    }

    return heroes;
  }

  private async Task<List<Villain>> ResolveVillains(IReadOnlyList<Guid> villainIds)
  {
    List<Villain> villains = new();

    foreach (var villainId in villainIds)
    {
      if (villainId == Guid.Empty) continue;
      var villain = await _villainService.FindVillainById(villainId);
      if (villain is not null) villains.Add(villain);
    }

    return villains;
  }
}
