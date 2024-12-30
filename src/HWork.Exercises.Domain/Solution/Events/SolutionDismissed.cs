using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution.Events;

public sealed record SolutionDismissed() : DomainEvent(DateTimeOffset.Now);
