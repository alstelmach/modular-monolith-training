using HWork.Shared.Domain;

namespace HWork.Shared.Application.Abstractions.Transactionality;

public interface IUnitOfWorkSetup
{
    void RegisterRepository<TAggregateRoot, TKey>(IRepository<TAggregateRoot, TKey> repository)
        where TAggregateRoot : AggregateRoot<TKey>
        where TKey : notnull;
}
