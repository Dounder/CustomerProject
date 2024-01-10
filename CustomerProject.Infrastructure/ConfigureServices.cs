using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Other infrastructure services like EmailService, Logging, etc.

        return services;
    }
}