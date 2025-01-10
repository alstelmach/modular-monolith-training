using HWork.Reviews.Api.Entities;
using HWork.Reviews.Api.Events.Integration.SolutionScoreChanged;
using HWork.Reviews.Api.Exceptions;
using HWork.Reviews.Api.Repositories;
using HWork.Shared.Application.Abstractions.Messaging;
using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Reviews.Api.Commands;

public sealed class ReviewCommandHandler : ICommandHandler<ReviewCommand>
{
    private readonly SolutionRepository _solutionRepository;
    private readonly IIntegrationEventPublisher _publisher;

    public ReviewCommandHandler(SolutionRepository solutionRepository,
        IIntegrationEventPublisher publisher)
    {
        _solutionRepository = solutionRepository;
        _publisher = publisher;
    }
    
    public async Task Handle(
        ReviewCommand request,
        CancellationToken cancellationToken)
    {
        var solution = await _solutionRepository.GetAsync(request.SolutionId);

        if (solution is null)
        {
            throw new SolutionNotFoundException(request.SolutionId);
        }
        
        solution.Reviews.Add(
            new Review(
                request.ReviewId,
                request.ReviewerId,
                request.Rating));

        // This is obviously dumb
        solution.Score += 1;

        await _solutionRepository.UpdateAsync(solution);

        await _publisher.PublishAsync(new SolutionScoreChanged(
            solution.Id,
            solution.Score,
            string.Empty,
            DateTimeOffset.Now));
    }
}