using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface IMovieService
{
  IQueryable<Movie> Query();
}
