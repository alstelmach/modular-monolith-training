namespace HWork.Shared.Domain;

public interface IRepository<TAggregateRoot, TKey> where TAggregateRoot : AggregateRoot<TKey>
{
}
