using Microsoft.EntityFrameworkCore;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;
using ArcadiaApi.Infrastructure.Persistence;

namespace ArcadiaApi.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
  private readonly AppDbContext _context;

  public TeamRepository(AppDbContext context)
  {
    _context = context;
  }

  public IQueryable<Team> Query() => _context.Set<Team>().AsNoTracking();

  public async Task<Team?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Set<Team>()
      .Include(team => team.SuperHeroes)
      .Include(team => team.Villains)
      .FirstOrDefaultAsync(team => team.Id == id, cancellationToken);
  }

  public Task AddAsync(Team team, CancellationToken cancellationToken = default)
  {
    _context.Set<Team>().Add(team);
    return Task.CompletedTask;
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return _context.SaveChangesAsync(cancellationToken);
  }
}
