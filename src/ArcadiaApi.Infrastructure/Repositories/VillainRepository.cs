using Microsoft.EntityFrameworkCore;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;
using ArcadiaApi.Infrastructure.Persistence;

namespace ArcadiaApi.Infrastructure.Repositories;

public class VillainRepository : IVillainRepository
{
  private readonly AppDbContext _context;

  public VillainRepository(AppDbContext context)
  {
    _context = context;
  }

  public IQueryable<Villain> Query() => _context.Set<Villain>().AsNoTracking();

  public async Task<Villain?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Set<Villain>().FindAsync(new object[] { id }, cancellationToken);
  }

  public Task AddAsync(Villain villain, CancellationToken cancellationToken = default)
  {
    _context.Set<Villain>().Add(villain);
    return Task.CompletedTask;
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return _context.SaveChangesAsync(cancellationToken);
  }
}
