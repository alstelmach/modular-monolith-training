using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Exercise;

public interface IExerciseRepository : ICrudRepository<Exercise, ExerciseId>;
