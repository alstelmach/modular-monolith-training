using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution.ValueObjects;

public sealed record SolutionId(Guid Value) : ValueObject;
