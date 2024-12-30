using System.Reflection;
using HWork.Shared.Application.Abstractions.Messaging;
using HWork.Shared.Application.Abstractions.Transactionality;
using HWork.Shared.Infrastructure.Messaging;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HWork.Shared.Infrastructure.DependencyInjection;

public static class MessagingDependencyInjectionRegistry
{
    public static IServiceCollection AddMessaging(this IServiceCollection services) =>
        services
            .AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            })
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionalPipelineBehavior<,>))
            .AddScoped<IDomainEventPublisher, DomainEventPublisher>()
            .AddScoped<ICommandBus, CommandBus>();
}