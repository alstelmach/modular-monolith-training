namespace HWork.Shared.Domain;

public abstract class AggregateRoot<TKey>(TKey id) : Entity<TKey>(id)
{
    private readonly Queue<DomainEvent> _domainEvents = new();

    protected void Enqueue(DomainEvent domainEvent) =>
        _domainEvents.Enqueue(domainEvent);

    public DomainEvent[] ReleaseDomainEvents()
    {
        var releasedEvents = _domainEvents.ToArray();

        _domainEvents.Clear();

        return releasedEvents;
    }
}
