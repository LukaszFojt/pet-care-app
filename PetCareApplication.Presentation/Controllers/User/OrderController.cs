using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Application.Queries.User;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : CommonCrudController<OrderEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allByUserId/{userId}")]
        public async Task<ActionResult<List<OrderEntity>>> GetOrdersByUserId(string userId)
        {
            try
            {
                var query = new GetOrdersByUserIdQuery(userId);
                var orders = await _mediator.Send(query);

                if (orders == null || orders.Count == 0)
                {
                    return NotFound("No orders found for the given user.");
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "No orders found for the given user: {UserId}", userId);
                return StatusCode(500, $"Error occurred: {ex.Message}. Try again later");
            }
        }
    }
}
