using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface ISuperHeroRepository
{
  IQueryable<SuperHero> Query();
  Task<SuperHero?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
  Task AddAsync(SuperHero hero, CancellationToken cancellationToken = default);
  Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
