using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Services;

public class MovieService : IMovieService
{
  private readonly IMovieRepository _repository;

  public MovieService(IMovieRepository repository)
  {
    _repository = repository;
  }

  public IQueryable<Movie> Query() => _repository.Query();
}
