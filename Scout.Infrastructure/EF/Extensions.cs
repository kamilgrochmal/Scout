using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scout.Domain.Repositories;
using Scout.Infrastructure.EF.Repositories;

namespace Scout.Infrastructure.EF;

public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        
        
        services.AddDbContext<ScoutDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"),
                    opt => { opt.CommandTimeout(30); }).LogTo(Console.WriteLine, new[]
                {
                    DbLoggerCategory.Database.Command.Name,
                }, LogLevel.Information)
                .EnableSensitiveDataLogging();

        });

        services.AddScoped<IScoutObjectRepository, ScoutObjectRepository>();
        
        return services;
    }
}