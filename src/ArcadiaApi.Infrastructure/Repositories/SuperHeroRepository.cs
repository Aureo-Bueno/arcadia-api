using Microsoft.EntityFrameworkCore;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;
using ArcadiaApi.Infrastructure.Persistence;

namespace ArcadiaApi.Infrastructure.Repositories;

public class SuperHeroRepository : ISuperHeroRepository
{
  private readonly AppDbContext _context;

  public SuperHeroRepository(AppDbContext context)
  {
    _context = context;
  }

  public IQueryable<SuperHero> Query() => _context.Set<SuperHero>().AsNoTracking();

  public async Task<SuperHero?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Set<SuperHero>().FindAsync(new object[] { id }, cancellationToken);
  }

  public Task AddAsync(SuperHero hero, CancellationToken cancellationToken = default)
  {
    _context.Set<SuperHero>().Add(hero);
    return Task.CompletedTask;
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return _context.SaveChangesAsync(cancellationToken);
  }
}
