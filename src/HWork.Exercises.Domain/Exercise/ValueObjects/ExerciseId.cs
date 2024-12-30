using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Exercise.ValueObjects;

public sealed record ExerciseId(Guid Value) : ValueObject;
