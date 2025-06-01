using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.User
{
    public class ConditionToUserTieRepository(PetCareApplicationDbContext dbContext) : IConditionToUserTieRepository
    {

    }
}
