using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface IVillainService
{
  IQueryable<Villain> Query();
  Task<Villain> AddVillain(string name, string? description, int? powerLevel);
  Task<Villain> UpdateVillain(Guid id, string? name, string? description, int? powerLevel);
  Task<Villain?> FindVillainById(Guid? id);
}
