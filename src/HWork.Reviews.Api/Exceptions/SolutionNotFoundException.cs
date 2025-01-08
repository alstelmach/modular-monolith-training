namespace HWork.Reviews.Api.Exceptions;

public sealed class SolutionNotFoundException(Guid solutionId)
    : Exception($"Solution {solutionId} is not found");