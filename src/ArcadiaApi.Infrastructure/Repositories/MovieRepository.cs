using Microsoft.EntityFrameworkCore;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;
using ArcadiaApi.Infrastructure.Persistence;

namespace ArcadiaApi.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
  private readonly AppDbContext _context;

  public MovieRepository(AppDbContext context)
  {
    _context = context;
  }

  public IQueryable<Movie> Query() => _context.Set<Movie>().AsNoTracking();

  public async Task<Movie?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Set<Movie>().FindAsync(new object[] { id }, cancellationToken);
  }

  public Task AddAsync(Movie movie, CancellationToken cancellationToken = default)
  {
    _context.Set<Movie>().Add(movie);
    return Task.CompletedTask;
  }

  public Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return _context.SaveChangesAsync(cancellationToken);
  }
}
