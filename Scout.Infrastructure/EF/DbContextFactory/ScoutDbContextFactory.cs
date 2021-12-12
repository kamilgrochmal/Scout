using Microsoft.EntityFrameworkCore;

namespace Scout.Infrastructure.EF.DbContextFactory;

public class ScoutDbContextFactory : DesignTimeDbContextFactoryBase<ScoutDbContext>
{
    protected override ScoutDbContext CreateNewInstance(DbContextOptions<ScoutDbContext> options)
    {
        return new ScoutDbContext(options);
    }
}