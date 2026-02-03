using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface IVillainRepository
{
  IQueryable<Villain> Query();
  Task<Villain?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
  Task AddAsync(Villain villain, CancellationToken cancellationToken = default);
  Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
