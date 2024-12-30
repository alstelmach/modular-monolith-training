using HWork.Exercises.Domain.Exercise.ValueObjects;

namespace HWork.Exercises.Application.Exercise.Exceptions;

public sealed class ExerciseNotFoundException(ExerciseId exerciseId)
    : Exception($"Exercise {exerciseId.Value} is not found");
