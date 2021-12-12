using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scout.Application.Common.Services;
using Scout.Infrastructure.Common.DateService;
using Scout.Infrastructure.EF;

namespace Scout.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddPersistence(configuration);
        
        services.AddScoped<IDateService, DateService>();

        return services;
    }
}