using HWork.Shared.Domain;

namespace HWork.Shared.Application.Abstractions.Services;

public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : DomainEvent
{
    Task HandleAsync(TDomainEvent @event);
}
