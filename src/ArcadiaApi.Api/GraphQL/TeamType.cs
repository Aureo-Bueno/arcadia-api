using HotChocolate.Data;
using HotChocolate.Types;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Api.GraphQL;

public class TeamType : ObjectType<Team>
{
  protected override void Configure(IObjectTypeDescriptor<Team> descriptor)
  {
    descriptor.Field(team => team.SuperHeroes).UseSorting();
    descriptor.Field(team => team.Villains).UseSorting();
  }
}
