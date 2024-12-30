namespace HWork.Shared.Domain;

public interface ICrudRepository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>
    where TAggregateRoot : AggregateRoot<TKey>
{
    Task<TAggregateRoot> CreateAsync(TAggregateRoot aggregateRoot);

    Task<IEnumerable<TAggregateRoot>> GetAsync(
        CancellationToken cancellationToken = default);

    Task<TAggregateRoot?> GetAsync(
        TKey id,
        CancellationToken cancellationToken = default);

    Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregateRoot);

    Task DeleteAsync(TKey id);
}
