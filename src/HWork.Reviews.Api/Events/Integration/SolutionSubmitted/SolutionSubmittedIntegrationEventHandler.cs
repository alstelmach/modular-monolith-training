using HWork.Reviews.Api.Entities;
using HWork.Reviews.Api.Repositories;
using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Reviews.Api.Events.Integration.SolutionSubmitted;

public class SolutionSubmittedIntegrationEventHandler(SolutionRepository solutionRepository)
    : IIntegrationEventHandler<SolutionSubmitted>
{
    public async Task HandleAsync(SolutionSubmitted @event)
    {
        await solutionRepository.CreateAsync(
            new Solution(
                @event.SolutionId,
                @event.SentAt,
                0.0,
                new List<Review>()));
    }
}
