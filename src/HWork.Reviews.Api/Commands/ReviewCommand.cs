using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Reviews.Api.Commands;

public sealed record ReviewCommand(
    Guid SolutionId,
    Guid ReviewerId,
    double Rating) : ICommand
{
    public Guid ReviewId { get; } = Guid.NewGuid();
}
