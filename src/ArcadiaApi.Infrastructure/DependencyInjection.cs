using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ArcadiaApi.Application.Interfaces;
using ArcadiaApi.Infrastructure.Interceptors;
using ArcadiaApi.Infrastructure.Persistence;
using ArcadiaApi.Infrastructure.Repositories;

namespace ArcadiaApi.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
  {
    services.AddSingleton<SlowQueryInterceptor>();

    services.AddDbContext<AppDbContext>(options =>
    {
      options.UseNpgsql(connectionString, npgsql =>
        npgsql.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
    });

    services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();
    services.AddScoped<IPowerRepository, PowerRepository>();
    services.AddScoped<IMovieRepository, MovieRepository>();
    services.AddScoped<IVillainRepository, VillainRepository>();
    services.AddScoped<ITeamRepository, TeamRepository>();

    return services;
  }
}
