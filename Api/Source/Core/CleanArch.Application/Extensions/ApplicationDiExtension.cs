using CleanArch.Application.Shared.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application.Extensions;

public static class ApplicationDiExtension
{
    public static void AddApplicationLayer(this IServiceCollection self)
    {
        var currentAssembly = typeof(ApplicationDiExtension).Assembly;

        self.AddAutoMapper(currentAssembly);
        
        self.AddMediatR(config 
            => config.RegisterServicesFromAssembly(currentAssembly));

        self.AddValidatorsFromAssembly(currentAssembly);

        self.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}