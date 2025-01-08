using HWork.Reviews.Api.Entities;
using HWork.Shared.Infrastructure.Persistence;

namespace HWork.Reviews.Api.Repositories;

public sealed class SolutionRepository : InMemoryRepository<Solution, Guid>;
