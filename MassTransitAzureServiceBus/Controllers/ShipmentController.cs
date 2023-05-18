using MassTransit;
using MassTransitAzureServiceBus.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitAzureServiceBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController :
        ControllerBase
    {
        readonly ILogger<ShipmentController> _logger;
        readonly IPublishEndpoint _publishEndpoint;

        public ShipmentController(ILogger<ShipmentController> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid orderId)
        {
            await _publishEndpoint.Publish(new OrderShipped
            {
                OrderId = orderId,
                Timestamp = DateTimeOffset.Now
            });

            return Ok(new { OrderId = orderId });
        }
    }
}
