using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution.ValueObjects;

public sealed record Score(double Value) : ValueObject
{
    public static Score CreateEmpty() =>
        new (0.0d);
}
