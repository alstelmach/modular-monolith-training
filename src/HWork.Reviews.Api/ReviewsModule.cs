using HWork.Reviews.Api.Events.Integration.SolutionSubmitted;
using HWork.Reviews.Api.Infrastructure;
using HWork.Shared.Abstractions;
using HWork.Shared.Application.Abstractions.Services;
using HWork.Shared.Infrastructure.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace HWork.Reviews.Api;

public sealed class ReviewsModule : IModule
{
    public string Name =>
        "Reviews";

    public IServiceCollection AddModuleDependencies(IServiceCollection services)
    {
        var assemblyPart = new AssemblyPart(GetType().Assembly);
        
        services
            .AddSingleton<IntegrationEventListener<SolutionSubmitted>>()
            .AddHostedService<IntegrationEventsHostedService>()
            .AddScoped<IIntegrationEventHandler<SolutionSubmitted>, SolutionSubmittedIntegrationEventHandler>()
            .AddControllers()
            .PartManager
            .ApplicationParts
            .Add(assemblyPart);

        return services;
    }

    public void UseModuleMiddlewares(IApplicationBuilder app)
    {
    }
}