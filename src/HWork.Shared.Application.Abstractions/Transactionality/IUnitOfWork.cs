using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Shared.Application.Abstractions.Transactionality;

public interface IUnitOfWork<TCommand> where TCommand : ICommand
{
    Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> operation);
}
