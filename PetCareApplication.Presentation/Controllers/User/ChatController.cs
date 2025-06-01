using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Infrastructure.DbContexts;
using PetCareApplication.Infrastructure.Hubs;

namespace PetCareApplication.Presentation.Controllers.User
{
    [Route("chat")]
    [ApiController]
    public class ChatController(IHubContext<ChatHub> hubContext, PetCareApplicationDbContext context) : ControllerBase
    {
        [HttpPost("sendMessageToUsers")]
        public async Task<IActionResult> SendMessageToUsers([FromBody] ChatMessageEntity message)
        {
            if (message == null || string.IsNullOrEmpty(message.SenderId) || message.Recipients == null || !message.Recipients.Any())
            {
                return BadRequest(new { Error = "Invalid message data." });
            }

            context.ChatMessages.Add(message);
            await context.SaveChangesAsync();

            foreach (var recipient in message.Recipients)
            {
                recipient.ChatMessageId = message.Id;

                bool exists = await context.ChatMessageRecipients
                    .AnyAsync(r => r.ChatMessageId == recipient.ChatMessageId && r.RecipientId == recipient.RecipientId);

                if (!exists)
                {
                    context.ChatMessageRecipients.Add(recipient);
                }

                await hubContext.Clients.User(recipient.RecipientId)
                    .SendAsync("ReceiveMessage", message.SenderId, message.Description);
            }

            await context.SaveChangesAsync();

            return Ok(new { Status = "Messages Sent", MessageId = message.Id });
        }

        [HttpPost("sendMessageToUser")]
        public async Task<IActionResult> SendMessageToUser([FromBody] ChatMessageEntity message)
        {
            if (message == null || string.IsNullOrEmpty(message.SenderId) || string.IsNullOrEmpty(message.RecipientId))
            {
                return BadRequest(new { Error = "Invalid message data." });
            }

            context.ChatMessages.Add(message);
            await context.SaveChangesAsync();

            var recipient = new ChatMessageRecipientEntity
            {
                ChatMessageId = message.Id,
                SenderId = message.SenderId,
                RecipientId = message.RecipientId,
                IsRead = false
            };

            context.ChatMessageRecipients.Add(recipient);
            await context.SaveChangesAsync();

            await hubContext.Clients.User(message.RecipientId)
                .SendAsync("ReceiveMessage", message.SenderId, message.Description);

            return Ok(new { Status = "Message Sent", MessageId = message.Id });
        }
    }
}
