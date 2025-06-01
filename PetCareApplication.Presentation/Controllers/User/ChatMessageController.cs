using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetCareApplication.Application.Queries.User;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers
{
    [Route("message")]
    [ApiController]
    public class ChatMessageController : CommonCrudController<ChatMessageEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ChatMessageController> _logger;

        public ChatMessageController(IMediator mediator, ILogger<ChatMessageController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("getByUserId/{userId}")]
        public async Task<ActionResult<List<ChatMessageEntity>>> GetMessagesByUserId(string userId)
        {
            try
            {
                var query = new GetMessagesByUserIdQuery(userId);
                var messages = await _mediator.Send(query);

                if (messages == null || messages.Count == 0)
                {
                    return NotFound("No messages found for the given user.");
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "No messages found for the given user: {UserId}", userId);
                return StatusCode(500, $"Error occurred: {ex.Message}. Try again later");
            }
        }

        [HttpGet("getMessagesBetweenUsers")]
        public async Task<ActionResult<List<ChatMessageEntity>>> GetMessagesBetweenUsers(string senderId, string recipientId)
        {
            try
            {
                var query = new GetMessagesBetweenUsersQuery(senderId, recipientId);
                var messages = await _mediator.Send(query);

                if (messages == null || messages.Count == 0)
                {
                    return NotFound("No messages found for the given user.");
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "No messages found for the given user: {SenderId}", senderId);
                return StatusCode(500, $"Error occurred: {ex.Message}. Try again later");
            }
        }
    }
}
