namespace HWork.Shared.Domain;

public abstract class Entity<TKey>(TKey id)
{
    public TKey Id { get; } = id;
}
