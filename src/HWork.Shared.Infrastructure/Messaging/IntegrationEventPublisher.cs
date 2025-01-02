using HWork.Shared.Application.Abstractions.Contracts;
using HWork.Shared.Application.Abstractions.Messaging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace HWork.Shared.Infrastructure.Messaging;

public sealed class IntegrationEventPublisher(IOptions<ExternalMessagingConfiguration> options)
    : IIntegrationEventPublisher
{
    public async Task PublishAsync(IntegrationEvent integrationEvent)
    {
        var factory = new ConnectionFactory
        {
            HostName = options.Value.HostName,
            Port = options.Value.Port,
        };

        var queueName = integrationEvent.GetType().Name;

        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queueName,
            true,
            false,
            false);
        
        var message = JsonSerializer.Serialize(integrationEvent);
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            string.Empty,
            queueName,
            true,
            body);
    }
}