using Microsoft.Extensions.DependencyInjection;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Application.Services;

namespace ArcadiaApi.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<ISuperHeroService, SuperHeroService>();
    services.AddScoped<IPowerService, PowerService>();
    services.AddScoped<IMovieService, MovieService>();
    services.AddScoped<IVillainService, VillainService>();
    services.AddScoped<ITeamService, TeamService>();
    services.AddScoped<ICombatService, CombatService>();

    return services;
  }
}
