using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using HWork.Shared.Application.Abstractions.Contracts;
using HWork.Shared.Application.Abstractions.Messaging;
using HWork.Shared.Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace HWork.Shared.Infrastructure.Messaging;

public sealed class IntegrationEventListener<TEvent>(
    IServiceProvider serviceProvider,
    IOptions<ExternalMessagingConfiguration> options)
    where TEvent : IntegrationEvent
{
    public async Task StartListeningAsync()
    {
        var factory = new ConnectionFactory
        {
            HostName = options.Value.HostName,
            Port = options.Value.Port,
        };

        var queueName = typeof(TEvent).Name;
        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            try
            {
                var integrationEvent = JsonConvert.DeserializeObject<TEvent>(message);

                if (integrationEvent != null)
                {
                    using var scope = serviceProvider.CreateScope();
                    var handler = scope.ServiceProvider.GetRequiredService<IIntegrationEventHandler<TEvent>>();

                    await handler.HandleAsync(integrationEvent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message: {ex.Message}");
            }
        };

        await channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: true,
            consumer: consumer);

        Console.WriteLine($"Listening for messages on queue '{queueName}'...");
    }
}
