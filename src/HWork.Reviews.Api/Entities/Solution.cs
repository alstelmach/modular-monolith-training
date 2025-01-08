using HWork.Shared.Domain;

namespace HWork.Reviews.Api.Entities;

public sealed class Solution(Guid id, DateTimeOffset createdAt, ICollection<Review> reviews) : AggregateRoot<Guid>(id)
{
    public DateTimeOffset CreatedAt { get; init; } = createdAt;

    public ICollection<Review> Reviews { get; init; } = reviews;
}
