using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution.Events;

public sealed record SolutionPublished() : DomainEvent(DateTimeOffset.Now);
