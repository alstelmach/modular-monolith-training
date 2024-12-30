using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution;

public interface ISolutionRepository : ICrudRepository<Solution, SolutionId>;
