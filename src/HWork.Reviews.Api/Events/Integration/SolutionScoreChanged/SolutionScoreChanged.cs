using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Reviews.Api.Events.Integration.SolutionScoreChanged;

public record SolutionScoreChanged(
    Guid SolutionId,
    double Score,
    string ScoreDescription,
    DateTimeOffset SentAt) : IntegrationEvent(SentAt);