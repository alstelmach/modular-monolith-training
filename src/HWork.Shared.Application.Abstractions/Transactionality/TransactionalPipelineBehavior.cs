using System.Reflection;
using HWork.Shared.Application.Abstractions.Contracts;
using HWork.Shared.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HWork.Shared.Application.Abstractions.Transactionality;

public class TransactionalPipelineBehavior<TRequest, TResponse>(IServiceProvider serviceProvider)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var unitOfWork = serviceProvider.GetService<IUnitOfWork<TRequest>>();

        if (unitOfWork == null)
        {
            return await next();
        }

        var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest>>();
        var repositories = handler
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Cast<MemberInfo>()
            .Concat(
                handler
                    .GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            .Where(member =>
                member.GetMemberType().ImplementsGenericInterface(typeof(IRepository<,>)))
            .Select(member => member.GetValue(handler))
            .Where(repository => repository != null)
            .ToList();

        foreach (var repository in repositories)
        {
            var repositoryType = repository!.GetType();
            var genericArguments = repositoryType.BaseType?.GetGenericArguments()!;
            
            typeof(IUnitOfWorkSetup)
                .GetMethod(nameof(IUnitOfWorkSetup.RegisterRepository))
                ?.MakeGenericMethod(
                    genericArguments[0],
                    genericArguments[1])
                .Invoke(unitOfWork, [repository]);
        }

        return await unitOfWork.ExecuteAsync(() => next());
    }
}