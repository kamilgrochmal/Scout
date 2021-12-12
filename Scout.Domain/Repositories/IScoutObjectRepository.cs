using Scout.Domain.ScoutObjects.Entities;

namespace Scout.Domain.Repositories;

public interface IScoutObjectRepository
{
    Task<ScoutObject> GetAsync(long scoutObjectId);
    Task AddAsync(ScoutObject scoutObject);
    Task UpdateAsync(ScoutObject scoutObject);
    Task RemoveAsync(ScoutObject scoutObject);
}