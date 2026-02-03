using Microsoft.Extensions.Logging;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Services;

public class SuperHeroService : ISuperHeroService
{
  private readonly ISuperHeroRepository _repository;
  private readonly ILogger<SuperHeroService> _logger;

  public SuperHeroService(ISuperHeroRepository repository, ILogger<SuperHeroService> logger)
  {
    _repository = repository;
    _logger = logger;
  }

  public IQueryable<SuperHero> Query() => _repository.Query();

  public async Task<SuperHero> AddSuperHero(string name, string description, int? powerLevel)
  {
    SuperHero hero = new()
    {
      Name = name,
      Description = description,
      PowerLevel = powerLevel ?? 0,
    };

    await _repository.AddAsync(hero);
    await _repository.SaveChangesAsync();

    _logger.LogInformation("Added SuperHero {Name}", name);
    return hero;
  }

  public async Task<SuperHero> UpdateSuperHero(Guid id, string? name, string? description, int? powerLevel)
  {
    var hero = await _repository.FindByIdAsync(id);
    if (hero is null)
    {
      _logger.LogError("SuperHero {Id} not found", id);
      throw new Exception("SuperHero not found");
    }

    if (name != null) hero.Name = name;
    if (description != null) hero.Description = description;
    if (powerLevel != null) hero.PowerLevel = powerLevel.Value;

    await _repository.SaveChangesAsync();
    _logger.LogInformation("Updated SuperHero {Id}", hero.Id);
    return hero;
  }

  public async Task<SuperHero?> FindSuperHeroById(Guid? id)
  {
    if (id is null)
      throw new ArgumentNullException(nameof(id), "SuperHero ID cannot be null.");

    return await _repository.FindByIdAsync(id.Value)
           ?? throw new System.Collections.Generic.KeyNotFoundException($"SuperHero with id {id} not found.");
  }
}
