using HWork.Exercises.Application.Exercise.Exceptions;
using HWork.Exercises.Domain.Exercise;
using HWork.Exercises.Domain.Solution;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Exercises.Application.Exercise.Commands.SolveExercise;

public sealed class SolveExerciseCommandHandler : ICommandHandler<SolveExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly ISolutionRepository _solutionRepository;

    public SolveExerciseCommandHandler(
        IExerciseRepository exerciseRepository,
        ISolutionRepository solutionRepository)
    {
        _exerciseRepository = exerciseRepository;
        _solutionRepository = solutionRepository;
    }
    
    public async Task Handle(
        SolveExerciseCommand command,
        CancellationToken cancellationToken)
    {
        var exercise = await _exerciseRepository.GetAsync(
            command.ExerciseId,
            cancellationToken);

        if (exercise is null)
        {
            throw new ExerciseNotFoundException(command.ExerciseId);
        }
        
        var solution = new Domain.Solution.Solution(
            command.SolutionId,
            exercise.Id,
            command.SolutionContent,
            Score.CreateEmpty());

        exercise.Solve(solution.Id);

        await _solutionRepository.CreateAsync(solution);
        await _exerciseRepository.UpdateAsync(exercise);
    }
}
