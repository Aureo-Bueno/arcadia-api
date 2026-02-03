using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface IMovieRepository
{
  IQueryable<Movie> Query();
  Task<Movie?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
  Task AddAsync(Movie movie, CancellationToken cancellationToken = default);
  Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
