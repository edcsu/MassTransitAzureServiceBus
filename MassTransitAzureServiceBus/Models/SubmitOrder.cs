namespace MassTransitAzureServiceBus.Models
{
    public record SubmitOrder
    {
        public Guid OrderId { get; init; }

        public DateTimeOffset Timestamp { get; init; }

        public string OrderNumber { get; init; } = default!;
    }
}
