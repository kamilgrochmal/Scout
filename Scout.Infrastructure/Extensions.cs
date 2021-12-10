using Microsoft.Extensions.DependencyInjection;
using Scout.Application.Common.Services;
using Scout.Infrastructure.Common.DateService;

namespace Scout.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDateService, DateService>();

        return services;
    }
}