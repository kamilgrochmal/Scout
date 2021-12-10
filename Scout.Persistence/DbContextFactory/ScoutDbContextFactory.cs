using Microsoft.EntityFrameworkCore;

namespace Scout.Persistence.DbContextFactory;

public class ScoutDbContextFactory : DesignTimeDbContextFactoryBase<ScoutDbContext>
{
    protected override ScoutDbContext CreateNewInstance(DbContextOptions<ScoutDbContext> options)
    {
        return new ScoutDbContext(options);
    }
}