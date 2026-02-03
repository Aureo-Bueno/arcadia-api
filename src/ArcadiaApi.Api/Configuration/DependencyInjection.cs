using Microsoft.Extensions.DependencyInjection;
using ArcadiaApi.Api.GraphQL;

namespace ArcadiaApi.Api.Configuration;

public static class DependencyInjection
{
  public static IServiceCollection AddApi(this IServiceCollection services)
  {
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddGraphQLServer()
      .AddQueryType<Query>()
      .AddMutationType<Mutation>()
      .AddType<SuperHeroType>()
      .AddType<VillainType>()
      .AddType<TeamType>()
      .AddProjections()
      .AddFiltering()
      .AddSorting();

    return services;
  }
}
