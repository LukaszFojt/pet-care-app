using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Contracts.User
{
    public interface IUserRepository
    {
        Task<UserEntity> GetCurrentUser(string userId);
        Task<List<ChatMessageEntity>> GetMessagesByUserId(string userId);
        Task<bool> LogoutUser();
        Task<bool> RegisterUserAndNotify(string email, string password);
        Task<List<ChatMessageEntity>> GetMessagesBetweenUsers(string senderId, string recipientId);
        Task<List<OrderEntity>> GetOrdersByUserId(string userId);
    }
}
