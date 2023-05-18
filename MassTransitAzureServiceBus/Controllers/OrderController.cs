using MassTransit;
using MassTransitAzureServiceBus.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitAzureServiceBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController :
       ControllerBase
    {
        readonly IRequestClient<SubmitOrder> _client;
        readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IRequestClient<SubmitOrder> client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpPut]
        public async Task<IActionResult> Put(OrderModel order)
        {
            Response<OrderSubmissionAccepted> response = await _client.GetResponse<OrderSubmissionAccepted>(new SubmitOrder
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                Timestamp = DateTimeOffset.Now
            });

            return Accepted(response.Message);
        }
    }


    public record OrderModel
    {
        public Guid OrderId { get; init; }

        public string OrderNumber { get; init; } = default!;
    }
}
