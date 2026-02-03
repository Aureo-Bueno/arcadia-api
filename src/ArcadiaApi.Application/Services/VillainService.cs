using Microsoft.Extensions.Logging;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Services;

public class VillainService : IVillainService
{
  private readonly IVillainRepository _repository;
  private readonly ILogger<VillainService> _logger;

  public VillainService(IVillainRepository repository, ILogger<VillainService> logger)
  {
    _repository = repository;
    _logger = logger;
  }

  public IQueryable<Villain> Query() => _repository.Query();

  public async Task<Villain> AddVillain(string name, string? description, int? powerLevel)
  {
    Villain villain = new()
    {
      Name = name,
      Description = description,
      PowerLevel = powerLevel ?? 0,
    };

    await _repository.AddAsync(villain);
    await _repository.SaveChangesAsync();

    _logger.LogInformation("Added Villain {Name}", name);
    return villain;
  }

  public async Task<Villain> UpdateVillain(Guid id, string? name, string? description, int? powerLevel)
  {
    var villain = await _repository.FindByIdAsync(id);
    if (villain is null)
    {
      _logger.LogError("Villain {Id} not found", id);
      throw new Exception("Villain not found");
    }

    if (name is not null) villain.Name = name;
    if (description is not null) villain.Description = description;
    if (powerLevel is not null) villain.PowerLevel = powerLevel.Value;

    await _repository.SaveChangesAsync();
    _logger.LogInformation("Updated Villain {Id}", villain.Id);
    return villain;
  }

  public async Task<Villain?> FindVillainById(Guid? id)
  {
    if (id is null)
      throw new ArgumentNullException(nameof(id), "Villain ID cannot be null.");

    return await _repository.FindByIdAsync(id.Value)
           ?? throw new System.Collections.Generic.KeyNotFoundException($"Villain with id {id} not found.");
  }
}
