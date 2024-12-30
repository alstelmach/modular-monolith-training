using HWork.Exercises.Domain.Exercise;
using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Shared.Infrastructure.Persistence;

namespace HWork.Exercises.Infrastructure.Persistence;

public class ExerciseRepository : InMemoryRepository<Exercise, ExerciseId>, IExerciseRepository
{
}
