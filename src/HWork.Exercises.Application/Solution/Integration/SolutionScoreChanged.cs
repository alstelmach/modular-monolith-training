using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Exercises.Application.Solution.Integration;

public record SolutionScoreChanged(
    Guid SolutionId,
    double Score,
    DateTimeOffset SentAt) : IntegrationEvent(SentAt);
