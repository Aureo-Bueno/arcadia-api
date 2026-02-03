using HotChocolate;
using HotChocolate.Data;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Application.Models;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Api.GraphQL;
public class Query
{
  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<SuperHero> GetSuperHeroes([Service] ISuperHeroService service) => service.Query();

  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Movie> GetMovies([Service] IMovieService service) => service.Query();

  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Power> GetPowers([Service] IPowerService service) => service.Query();

  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Villain> GetVillains([Service] IVillainService service) => service.Query();

  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Team> GetTeams([Service] ITeamService service) => service.Query();

  public Task<CombatResult> Combat(
    Guid superHeroId,
    Guid villainId,
    [Service] ICombatService service) => service.Fight(superHeroId, villainId);
}
