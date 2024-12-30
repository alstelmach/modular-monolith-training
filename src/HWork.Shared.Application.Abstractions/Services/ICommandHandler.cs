using HWork.Shared.Application.Abstractions.Contracts;
using MediatR;

namespace HWork.Shared.Application.Abstractions.Services;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand;
