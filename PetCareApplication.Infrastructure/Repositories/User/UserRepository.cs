using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Infrastructure.DbContexts;
using PetCareApplication.Infrastructure.Services;

namespace PetCareApplication.Infrastructure.Repositories.User
{
    public class UserRepository(
        PetCareApplicationDbContext dbContext, 
        SignInManager<UserEntity> signInManager, 
        UserManager<UserEntity> userManager,
        IEmailNotifierService emailNotifier) : IUserRepository
    {
        public async Task<UserEntity> GetCurrentUser(string userId)
        {
            return await dbContext.Users.FindAsync(userId);
        }

        public async Task<bool> LogoutUser()
        {
            await signInManager.SignOutAsync();

            return true;
        }

        public async Task<List<ChatMessageEntity>> GetMessagesByUserId(string userId)
        {
            var user = await dbContext.Users
                .Include(u => u.SentMessages)
                .Include(u => u.ReceivedMessages)
                    .ThenInclude(rm => rm.ChatMessage)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return new List<ChatMessageEntity>();

            var messages = new List<ChatMessageEntity>();

            messages.AddRange(user.SentMessages);

            var receivedMessages = await dbContext.ChatMessageRecipients
                .Where(cr => cr.RecipientId == userId || cr.SenderId == userId)
                .Select(cr => cr.ChatMessage)
                .ToListAsync();

            messages.AddRange(receivedMessages);

            return messages;
        }

        public async Task<List<OrderEntity>> GetOrdersByUserId(string userId)
        {
            var orders = await dbContext.Orders
                .Where(cr => cr.EmployeeId == userId)
                .ToListAsync();

            return orders;
        }

        public async Task<List<ChatMessageEntity>> GetMessagesBetweenUsers(string senderId, string recipientId)
        {
            var messages = await dbContext.ChatMessages
                .Include(m => m.Recipients)
                .Where(m =>
                    (m.SenderId == senderId && m.Recipients.Any(r => r.RecipientId == recipientId)) ||
                    (m.SenderId == recipientId && m.Recipients.Any(r => r.RecipientId == senderId)))
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            return messages;
        }

        public async Task<bool> RegisterUserAndNotify(string email, string password)
        {
            var user = new UserEntity
            {
                UserName = email,
                Email = email
            };

            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return false;

            await emailNotifier.SendUserRegisteredEmail(user);
            return true;
        }
    }
}
