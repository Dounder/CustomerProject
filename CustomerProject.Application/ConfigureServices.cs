using CleanArch.Application.Common;
using CleanArch.Application.Common.Behaviors;
using CleanArch.Application.UseCases.Customers.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConfigureServices));

        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        });

        services.AddScoped<CustomerService>();

        return services;
    }
}