using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;
using ArcadiaApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ArcadiaApi.Infrastructure.Repositories;

public class PowerRepository : IPowerRepository
{
  private readonly AppDbContext _context;

  public PowerRepository(AppDbContext context)
  {
    _context = context;
  }

  public IQueryable<Power> Query() => _context.Set<Power>().AsNoTracking();

  public async Task<Power?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Set<Power>().FindAsync(new object[] { id }, cancellationToken);
  }

  public Task AddAsync(Power power, CancellationToken cancellationToken = default)
  {
    _context.Set<Power>().Add(power);
    return Task.CompletedTask;
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return _context.SaveChangesAsync(cancellationToken);
  }
}
