using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface ISuperHeroService
{
  IQueryable<SuperHero> Query();
  Task<SuperHero> AddSuperHero(string name, string description, int? powerLevel);
  Task<SuperHero> UpdateSuperHero(Guid id, string? name, string? description, int? powerLevel);
  Task<SuperHero?> FindSuperHeroById(Guid? id);
}
