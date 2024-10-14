using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HWork.Shared.Abstractions;

public interface IModule
{
    string Name { get; }
    IServiceCollection AddModuleDependencies(IServiceCollection services);
    void UseModuleMiddlewares(IApplicationBuilder app);
}
