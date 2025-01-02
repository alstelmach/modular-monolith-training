namespace HWork.Shared.Application.Abstractions.Messaging;

public record ExternalMessagingConfiguration
{
    public string HostName { get; init; }

    public int Port { get; init; }
}
