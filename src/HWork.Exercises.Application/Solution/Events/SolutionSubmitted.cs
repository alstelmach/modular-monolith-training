using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Exercises.Application.Solution.Events;

public sealed record SolutionSubmitted(
    Guid SolutionId,
    Guid ExerciseId,
    string Text,
    DateTimeOffset SentAt)
        : IntegrationEvent(SentAt);
