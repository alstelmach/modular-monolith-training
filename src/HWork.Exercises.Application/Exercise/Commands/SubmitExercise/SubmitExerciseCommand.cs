using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Exercises.Application.Exercise.Commands.SubmitExercise;

public record SubmitExerciseCommand(string Instructions) : ICommand
{
    public ExerciseId ExerciseId { get; } = new (Guid.NewGuid());
}
