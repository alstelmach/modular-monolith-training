using HWork.Exercises.Domain.Exercise;
using HWork.Exercises.Domain.Solution;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Exercises.Application.Solution.Integration;

public class SolutionScoreChangedIntegrationEventHandler : IIntegrationEventHandler<SolutionScoreChanged>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly ISolutionRepository _solutionRepository;

    public SolutionScoreChangedIntegrationEventHandler(
        IExerciseRepository exerciseRepository,
        ISolutionRepository solutionRepository)
    {
        _exerciseRepository = exerciseRepository;
        _solutionRepository = solutionRepository;
    }
    
    public async Task HandleAsync(SolutionScoreChanged @event)
    {
        var solution = await _solutionRepository.GetAsync(new SolutionId(@event.SolutionId));
        var exercise = await _exerciseRepository.GetAsync(solution.ExerciseId);
        
        exercise.
    }
}