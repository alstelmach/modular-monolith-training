using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution.Events;

public sealed record SolutionSubmitted(
    SolutionId SolutionId,
    ExerciseId ExerciseId,
    string Text) : DomainEvent(DateTimeOffset.Now);
