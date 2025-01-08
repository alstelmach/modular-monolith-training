namespace HWork.Reviews.Api.Entities;

public sealed record Review(
    Guid Id,
    Guid ReviewerId,
    double Rating);
