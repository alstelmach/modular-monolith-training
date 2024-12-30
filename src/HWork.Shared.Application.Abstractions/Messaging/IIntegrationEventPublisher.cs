using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Shared.Application.Abstractions.Messaging;

public interface IIntegrationEventPublisher
{
    Task PublishAsync(IntegrationEvent integrationEvent);
}
