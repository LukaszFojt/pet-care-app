using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Contracts.User
{
    public interface IUserInfoRepository
    {
        Task<UserInfoEntity?> GetUserInfoByUserId(string userId);
        Task<UserInfoEntity?> UpdateUserInfoByUserId(string userId, UserInfoEntity userInfo);
    }
}
