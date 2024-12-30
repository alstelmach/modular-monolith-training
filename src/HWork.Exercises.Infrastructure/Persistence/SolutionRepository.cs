using HWork.Exercises.Domain.Solution;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Infrastructure.Persistence;

namespace HWork.Exercises.Infrastructure.Persistence;

public sealed class SolutionRepository : InMemoryRepository<Solution, SolutionId>, ISolutionRepository;
