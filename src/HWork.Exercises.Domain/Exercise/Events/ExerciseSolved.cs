using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Exercise.Events;

public sealed record ExerciseSolved(
    ExerciseId ExerciseId,
    SolutionId SolutionId)
        : DomainEvent(DateTimeOffset.UtcNow);
