namespace MassTransitAzureServiceBus.Models
{
    public record OrderShipped
    {
        public Guid OrderId { get; init; }

        public DateTimeOffset Timestamp { get; init; }
    }
}
