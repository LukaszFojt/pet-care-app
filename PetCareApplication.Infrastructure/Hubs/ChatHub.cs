using Microsoft.AspNetCore.SignalR;
using PetCareApplication.Domain.Entities.User;
using System.Collections.Concurrent;

namespace PetCareApplication.Infrastructure.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> _userConnections = new();

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections[userId] = Context.ConnectionId;
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections.TryRemove(userId, out _);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToUsers(string senderId, List<ChatMessageRecipientEntity> recipients)
        {
            foreach (var recipient in recipients)
            {
                if (_userConnections.TryGetValue(recipient.RecipientId, out var connectionId))
                {
                    await Clients.Client(connectionId).SendAsync("ReceiveMessage", senderId, recipient.ChatMessage);
                }
            }
        }
    }
}
