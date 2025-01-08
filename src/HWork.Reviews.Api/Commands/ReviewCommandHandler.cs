using HWork.Reviews.Api.Entities;
using HWork.Reviews.Api.Exceptions;
using HWork.Reviews.Api.Repositories;
using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Reviews.Api.Commands;

public sealed class ReviewCommandHandler : ICommandHandler<ReviewCommand>
{
    private readonly SolutionRepository _solutionRepository;

    public ReviewCommandHandler(SolutionRepository solutionRepository)
    {
        _solutionRepository = solutionRepository;
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

        await _solutionRepository.UpdateAsync(solution);
    }
}