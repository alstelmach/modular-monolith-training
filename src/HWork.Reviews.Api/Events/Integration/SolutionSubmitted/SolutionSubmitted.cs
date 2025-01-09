using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Reviews.Api.Events.Integration.SolutionSubmitted;

public sealed record SolutionSubmitted(
    Guid SolutionId,
    string Text,
    DateTimeOffset SentAt) : IntegrationEvent(SentAt);
