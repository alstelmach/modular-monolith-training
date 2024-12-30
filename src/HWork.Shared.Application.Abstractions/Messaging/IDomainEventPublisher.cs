using HWork.Shared.Domain;

namespace HWork.Shared.Application.Abstractions.Messaging;

public interface IDomainEventPublisher
{
    Task PublishAsync(params DomainEvent[] events);
}
