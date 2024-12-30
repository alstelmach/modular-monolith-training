using HWork.Shared.Application.Abstractions.Messaging;
using HWork.Shared.Application.Abstractions.Services;
using HWork.Shared.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace HWork.Shared.Infrastructure.Messaging;

public sealed class DomainEventPublisher(IServiceProvider serviceProvider) : IDomainEventPublisher
{
    public async Task PublishAsync(params DomainEvent[] events)
    {
        if (!events.Any())
        {
            return;
        }

        using var scope = serviceProvider.CreateScope();

        foreach (var @event in events)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
            var handlers = scope.ServiceProvider.GetServices(handlerType);
                
            var tasks = handlers
                .Select(handler =>
                    (Task) handlerType
                    .GetMethod(nameof(IDomainEventHandler<DomainEvent>.HandleAsync))
                    ?.Invoke(handler, [@event])!);

            await Task.WhenAll(tasks);
        }
    }
}
