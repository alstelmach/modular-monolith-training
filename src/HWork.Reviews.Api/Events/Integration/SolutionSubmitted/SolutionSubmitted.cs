using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Reviews.Api.Events.Integration.SolutionSubmitted;

public record SolutionSubmitted(DateTimeOffset SentAt) : IntegrationEvent(SentAt);