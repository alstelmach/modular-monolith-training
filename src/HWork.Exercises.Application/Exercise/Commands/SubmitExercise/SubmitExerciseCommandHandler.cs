using HWork.Exercises.Domain.Exercise;
using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Shared.Application.Abstractions.Services;

namespace HWork.Exercises.Application.Exercise.Commands.SubmitExercise;

public sealed class SubmitExerciseCommandHandler(IExerciseRepository exerciseRepository) : ICommandHandler<SubmitExerciseCommand>
{
    public async Task Handle(
        SubmitExerciseCommand command,
        CancellationToken cancellationToken)
    {
        var instructions = new ExerciseInstructions(command.Instructions);
        var exercise = Domain.Exercise.Exercise.Create(command.ExerciseId, instructions);

        await exerciseRepository.CreateAsync(exercise);
    }
}
