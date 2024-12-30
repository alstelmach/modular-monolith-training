using HWork.Shared.Application.Abstractions.Messaging;
using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Exercises.Application.Solution.Events;

public sealed class SolutionSubmittedDomainEventHandler(IIntegrationEventPublisher integrationEventPublisher)
    : IDomainEventHandler<Domain.Solution.Events.SolutionSubmitted>
{
    public async Task HandleAsync(Domain.Solution.Events.SolutionSubmitted @event)
    {
        var timestamp = DateTimeOffset.UtcNow;
        var integrationEvent = new SolutionSubmitted(
            @event.SolutionId,
            @event.ExerciseId,
            @event.Text,
            timestamp);

        await integrationEventPublisher.PublishAsync(integrationEvent);
    }
}