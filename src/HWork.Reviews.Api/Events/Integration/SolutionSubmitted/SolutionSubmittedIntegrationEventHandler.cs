using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Reviews.Api.Events.Integration.SolutionSubmitted;

public class SolutionSubmittedIntegrationEventHandler : IIntegrationEventHandler<SolutionSubmitted>
{
    public Task HandleAsync(SolutionSubmitted @event)
    {
        throw new NotImplementedException();
    }
}