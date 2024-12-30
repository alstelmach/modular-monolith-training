using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Exercises.Application.Solution.Events;

public sealed record SolutionSubmitted(
    SolutionId SolutionId,
    ExerciseId ExerciseId,
    string Text,
    DateTimeOffset SentAt)
        : IntegrationEvent(SentAt);
