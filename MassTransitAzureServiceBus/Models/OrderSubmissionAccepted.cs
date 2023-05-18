namespace MassTransitAzureServiceBus.Models
{
    public record OrderSubmissionAccepted
    {
        public Guid OrderId { get; init; }

        public string OrderNumber { get; init; } = default!;
    }
}
