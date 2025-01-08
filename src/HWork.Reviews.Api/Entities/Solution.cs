using HWork.Shared.Domain;

namespace HWork.Reviews.Api.Entities;

public sealed class Solution(Guid id, DateTimeOffset createdAt, double score, ICollection<Review> reviews) : AggregateRoot<Guid>(id)
{
    public DateTimeOffset CreatedAt { get; init; } = createdAt;

    public double Score { get; set; } = score;

    public ICollection<Review> Reviews { get; init; } = reviews;
}
