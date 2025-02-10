using CleanArchitecture.Application.Behaviors;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application;

public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly);
            conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationRegistrar).Assembly);

        return services;
    }
}
