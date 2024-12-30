using System.Reflection;
using HWork.Shared.Application.Abstractions.Contracts;
using HWork.Shared.Application.Abstractions.Transactionality;
using HWork.Shared.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace HWork.Shared.Infrastructure.DependencyInjection;

public static class TransactionalityDependencyInjectionRegistry
{
    public static IServiceCollection UseTransactionsForCommands(
        this IServiceCollection services,
        Assembly[] assembliesToScan)
    {
        var commandTypes = assembliesToScan
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type =>
                typeof(ICommand).IsAssignableFrom(type)
                && type is { IsAbstract: false, IsInterface: false })
            .ToList();

        foreach (var commandType in commandTypes)
        {
            var unitOfWorkType = typeof(IUnitOfWork<>).MakeGenericType(commandType);
            var implementationType = typeof(InMemoryUnitOfWork<>).MakeGenericType(commandType);

            services.AddScoped(unitOfWorkType, implementationType);
        }

        return services;
    }
}
