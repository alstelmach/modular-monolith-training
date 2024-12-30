using HWork.Reviews.Api.Events.Integration;
using HWork.Reviews.Api.Events.Integration.SolutionSubmitted;
using HWork.Shared.Infrastructure.Messaging;
using Microsoft.Extensions.Hosting;

namespace HWork.Reviews.Api.Infrastructure;

public class IntegrationEventsHostedService(IntegrationEventListener<SolutionSubmitted> solutionSubmittedListener)
    : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await solutionSubmittedListener.StartListeningAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
