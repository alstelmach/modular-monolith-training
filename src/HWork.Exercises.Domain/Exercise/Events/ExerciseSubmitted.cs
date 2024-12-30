using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Exercise.Events;

public sealed record ExerciseSubmitted(ExerciseId ExerciseId) : DomainEvent(DateTimeOffset.Now);
