using HWork.Shared.Domain;

namespace HWork.Shared.Infrastructure.Persistence;

public abstract class InMemoryRepository<TAggregateRoot, TKey>
    : IRepository<TAggregateRoot, TKey>
    where TAggregateRoot : AggregateRoot<TKey>
    where TKey : notnull
{
    protected readonly Dictionary<TKey, TAggregateRoot> Storage = new();

    public virtual Task<TAggregateRoot> CreateAsync(TAggregateRoot aggregateRoot)
    {
        Storage[aggregateRoot.Id] = aggregateRoot;
        return Task.FromResult(aggregateRoot);
    }

    public virtual Task<IEnumerable<TAggregateRoot>> GetAsync(CancellationToken cancellationToken = default)
    {
        var result = Storage.Values.AsEnumerable();
        return Task.FromResult(result);
    }

    public virtual Task<TAggregateRoot?> GetAsync(
        TKey id,
        CancellationToken cancellationToken = default)
    {
        Storage.TryGetValue(id, out var aggregateRoot);
        return Task.FromResult(aggregateRoot);
    }

    public virtual Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregateRoot)
    {
        if (Storage.ContainsKey(aggregateRoot.Id))
        {
            Storage[aggregateRoot.Id] = aggregateRoot;
            return Task.FromResult(aggregateRoot);
        }

        return Task.FromResult<TAggregateRoot>(null!);
    }

    public virtual Task DeleteAsync(TKey id)
    {
        return Storage.Remove(id, out var value)
            ? Task.FromResult(value)
            : Task.CompletedTask;
    }
}
