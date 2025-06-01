using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.User
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly PetCareApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserInfoRepository(PetCareApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserInfoEntity?> GetUserInfoByUserId(string userId)
        {
            return await _dbContext.UserInfos.SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<UserInfoEntity?> UpdateUserInfoByUserId(string userId, UserInfoEntity updatedData)
        {
            try
            {
                var userInfo = await _dbContext.UserInfos.SingleOrDefaultAsync(x => x.UserId == userId);

                if (userInfo == null)
                {
                    return null;
                }

                _mapper.Map(updatedData, userInfo);

                _dbContext.UserInfos.Update(userInfo);
                await _dbContext.SaveChangesAsync();

                return userInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured: ", ex);
            }
        }
    }
}
