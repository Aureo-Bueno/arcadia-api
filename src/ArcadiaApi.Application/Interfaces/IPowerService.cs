using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface IPowerService
{
  IQueryable<Power> Query();
  Task<Power> AddPower(Guid? superHeroId, string? description, string? superPower);
  Task<Power> UpdatePower(Guid? id, Guid? superHeroId, string? description, string? superPower);
  Task<Power?> FindPowerById(Guid? id);
}
