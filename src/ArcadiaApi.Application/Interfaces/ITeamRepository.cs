using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface ITeamRepository
{
  IQueryable<Team> Query();
  Task<Team?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
  Task AddAsync(Team team, CancellationToken cancellationToken = default);
  Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
