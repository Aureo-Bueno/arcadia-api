using Microsoft.Extensions.Logging;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Services;

public class PowerService : IPowerService
{
  private readonly IPowerRepository _repository;
  private readonly ILogger<PowerService> _logger;
  private readonly ISuperHeroService _superHeroService;
  
  public PowerService(IPowerRepository repository, ILogger<PowerService> logger, ISuperHeroService superHeroService)
  {
    _repository = repository; 
    _logger = logger;
    _superHeroService = superHeroService;
  }

  public IQueryable<Power> Query() => _repository.Query();

  public async Task<Power> AddPower(Guid? superHeroId, string? description, string? superPower)
  {
    SuperHero? superHero =  await _superHeroService.FindSuperHeroById(superHeroId);

    if (superHero is null)
    {
      _logger.LogInformation("Super hero with id {Id} not found", superHeroId);
      throw new Exception("SuperHero not found");
    }
    
    Power power = new()
    {
      SuperHero = superHero,
      SuperHeroId = superHero.Id,
      Description = description,
      SuperPower = superPower,
    };
    
    await _repository.AddAsync(power);
    await _repository.SaveChangesAsync();
    return power;
  }

  public async Task<Power> UpdatePower(Guid? id, Guid? superHeroId, string? description, string? superPower)
  {
    Power? power = await FindPowerById(id);

    if (power is null)
    {
      _logger.LogError("Could not find power {Id}", id);
      throw new Exception("Power not found");
    }

    if (superHeroId is not null)
    {
      var hero = await _superHeroService.FindSuperHeroById(superHeroId);
      power.SuperHero = hero;
      power.SuperHeroId = hero.Id;
    }
    if (description is not null ) power.Description = description;
    if (superPower is not null) power.SuperPower = superPower;

    await _repository.SaveChangesAsync();
    _logger.LogInformation("Power {Id} was updated", id);
    return power;
  }

  public async Task<Power?> FindPowerById(Guid? id)
  {
    if (id is null)
      throw new ArgumentNullException(nameof(id), "Power ID cannot be null.");
    
    return await _repository.FindByIdAsync(id.Value)
           ?? throw new System.Collections.Generic.KeyNotFoundException($"Power with id {id} not found.");
  }
}
