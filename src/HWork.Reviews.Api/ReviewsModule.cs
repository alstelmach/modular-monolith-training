using HWork.Shared.Abstractions;
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