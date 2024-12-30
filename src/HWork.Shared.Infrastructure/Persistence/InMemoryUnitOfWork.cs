using System.Collections;
using System.Reflection;
using HWork.Shared.Application.Abstractions.Contracts;
using HWork.Shared.Application.Abstractions.Messaging;
using HWork.Shared.Application.Abstractions.Transactionality;
using HWork.Shared.Domain;

namespace HWork.Shared.Infrastructure.Persistence;

/// <summary>
/// AI generated unit of work pattern implementation for in-memory storage. Not the best one,
/// however, it should be enough for training purposes :)
/// </summary>
public class InMemoryUnitOfWork<TCommand>(IDomainEventPublisher domainEventPublisher)
    : IUnitOfWork<TCommand>, IUnitOfWorkSetup
    where TCommand : ICommand
{
    private readonly Dictionary<Type, object> _repositories = new();

    public void RegisterRepository<TAggregateRoot, TKey>(IRepository<TAggregateRoot, TKey> repository)
        where TAggregateRoot : AggregateRoot<TKey>
        where TKey : notnull
    {
        var type = repository.GetType();

        _repositories[type] = repository;
    }

    public Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> operation)
    {
        var snapshots = _repositories.ToDictionary(
            kvp => kvp.Key,
            kvp => CloneRepository(kvp.Value)
        );

        return ExecuteWithRollbackAsync(operation, snapshots);
    }

    private async Task<TResponse> ExecuteWithRollbackAsync<TResponse>(
        Func<Task<TResponse>> operation,
        Dictionary<Type, object> snapshots)
    {
        try
        {
            var response = await operation();

            await ReleaseDomainEventsAsync();

            return response;
        }
        catch
        {
            foreach (var (type, snapshot) in snapshots)
            {
                var storageField = GetFieldFromBaseType(
                    type,
                    "Storage",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                
                storageField!.SetValue(_repositories[type], snapshot);
            }

            throw;
        }
    }

    private static object CloneRepository(object repository)
    {
        var type = repository.GetType();

        var storageField = GetFieldFromBaseType(
            type,
            "Storage",
            BindingFlags.NonPublic | BindingFlags.Instance);

        var originalStorage = storageField!.GetValue(repository);
        var clonedStorage = CloneDictionary(originalStorage!);

        return clonedStorage;
    }

    private static object CloneDictionary(object dictionary)
    {
        var dictionaryType = dictionary.GetType();
        var clone = Activator.CreateInstance(dictionaryType)!;

        foreach (var kvp in (dynamic)dictionary)
        {
            ((dynamic)clone).Add(kvp.Key, kvp.Value);
        }

        return clone;
    }

    private async Task ReleaseDomainEventsAsync()
    {
        var domainEvents = new List<DomainEvent>();

        foreach (var repository in _repositories.Values)
        {
            var storageField = repository
                .GetType()
                .GetField(
                    "Storage",
                    BindingFlags.NonPublic | BindingFlags.Instance);

            if (storageField?.GetValue(repository) is IDictionary storage)
            {
                foreach (var aggregate in storage.Values)
                {
                    var releaseDomainEventsMethod = aggregate
                        .GetType()
                        .GetMethod("ReleaseDomainEvents");

                    if (releaseDomainEventsMethod != null)
                    {
                        var aggregateEvents = (DomainEvent[]) releaseDomainEventsMethod.Invoke(aggregate, null)!;
                        domainEvents.AddRange(aggregateEvents);
                    }
                }
            }
        }

        if (domainEvents.Any())
        {
            await domainEventPublisher.PublishAsync(domainEvents.ToArray());
        }
    }
    
    private static FieldInfo? GetFieldFromBaseType(Type type, string fieldName, BindingFlags bindingFlags)
    {
        while (type != null)
        {
            var field = type.GetField(fieldName, bindingFlags);

            if (field != null)
            {
                return field;
            }
            
            type = type.BaseType;
        }

        return null;
    }
}
