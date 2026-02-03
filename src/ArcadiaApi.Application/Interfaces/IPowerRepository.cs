using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface IPowerRepository
{
  IQueryable<Power> Query();
  Task<Power?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
  Task AddAsync(Power power, CancellationToken cancellationToken = default);
  Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
