using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Shared.Application.Abstractions.Services;

public interface IIntegrationEventHandler<in TIntegrationEvent> where TIntegrationEvent : IntegrationEvent
{
    Task HandleAsync(TIntegrationEvent @event);
}
