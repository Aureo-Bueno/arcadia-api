using HotChocolate.Data;
using HotChocolate.Types;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Api.GraphQL;

public class SuperHeroType : ObjectType<SuperHero>
{
  protected override void Configure(IObjectTypeDescriptor<SuperHero> descriptor)
  {
    descriptor.Field(hero => hero.Powers).UseSorting();
    descriptor.Field(hero => hero.Movies).UseSorting();
    descriptor.Field(hero => hero.Teams).UseSorting();
  }
}
