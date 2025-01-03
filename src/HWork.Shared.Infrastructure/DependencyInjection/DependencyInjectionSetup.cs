using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HWork.Shared.Infrastructure.DependencyInjection;

public static class DependencyInjectionSetup
{
    public static IServiceCollection AddInfrastructureDependencies(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddDocumentationDependencies()
            .AddMessaging(configuration);
}
