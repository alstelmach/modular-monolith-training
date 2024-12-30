using HWork.Shared.Application.Abstractions.Contracts;

namespace HWork.Shared.Application.Abstractions.Messaging;

public interface ICommandBus
{
    Task SendAsync(ICommand command);
}
