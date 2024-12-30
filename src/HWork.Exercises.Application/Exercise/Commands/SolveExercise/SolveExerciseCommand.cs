using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Exercises.Application.Exercise.Commands.SolveExercise;

public sealed record SolveExerciseCommand : ICommand
{
    public SolveExerciseCommand(
        Guid exerciseId,
        string solutionContent)
    {
        SolutionContent = solutionContent;
        ExerciseId = new ExerciseId(exerciseId);
    }

    public ExerciseId ExerciseId { get; }

    public string SolutionContent { get; }

    public SolutionId SolutionId { get; } = new (Guid.NewGuid());
}
