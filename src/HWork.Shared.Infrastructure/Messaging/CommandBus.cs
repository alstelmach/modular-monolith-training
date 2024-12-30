using HWork.Shared.Application.Abstractions.Contracts;
using HWork.Shared.Application.Abstractions.Messaging;
using MediatR;

namespace HWork.Shared.Infrastructure.Messaging;

public class CommandBus(IMediator mediator) : ICommandBus
{
    public async Task SendAsync(ICommand command) =>
        await mediator.Send(command);
}
