using Microsoft.EntityFrameworkCore;
using Scout.Domain.Repositories;
using Scout.Domain.ScoutObjects.Entities;

namespace Scout.Infrastructure.EF.Repositories;

public class ScoutObjectRepository : IScoutObjectRepository
{
    private readonly ScoutDbContext _dbContext;

    public ScoutObjectRepository(ScoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ScoutObject> GetAsync(long scoutObjectId)
    {
        return await _dbContext.ScoutObjects.FirstOrDefaultAsync(so => so.Id == scoutObjectId);
    }

    public async Task AddAsync(ScoutObject scoutObject)
    {
        await _dbContext.ScoutObjects.AddAsync(scoutObject);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ScoutObject scoutObject)
    {
        _dbContext.ScoutObjects.Update(scoutObject);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(ScoutObject scoutObject)
    {
        _dbContext.ScoutObjects.Remove(scoutObject);
        await _dbContext.SaveChangesAsync();
    }
}