using ArcadiaApi.Entities;

namespace ArcadiaApi.Application.Interfaces;

public interface ITeamService
{
  IQueryable<Team> Query();
  Task<Team> AddTeam(string name, string? description, IReadOnlyList<Guid>? superHeroIds, IReadOnlyList<Guid>? villainIds);
  Task<Team> UpdateTeam(Guid id, string? name, string? description, IReadOnlyList<Guid>? superHeroIds, IReadOnlyList<Guid>? villainIds);
  Task<Team> AddTeamMembers(Guid id, IReadOnlyList<Guid>? superHeroIds, IReadOnlyList<Guid>? villainIds);
  Task<Team> RemoveTeamMembers(Guid id, IReadOnlyList<Guid>? superHeroIds, IReadOnlyList<Guid>? villainIds);
  Task<Team?> FindTeamById(Guid? id);
}
