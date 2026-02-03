using HotChocolate.Data;
using HotChocolate.Types;
using ArcadiaApi.Entities;

namespace ArcadiaApi.Api.GraphQL;

public class VillainType : ObjectType<Villain>
{
  protected override void Configure(IObjectTypeDescriptor<Villain> descriptor)
  {
    descriptor.Field(villain => villain.Teams).UseSorting();
  }
}
