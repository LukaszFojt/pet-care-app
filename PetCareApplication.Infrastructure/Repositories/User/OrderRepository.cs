using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.User
{
    public class OrderRepository(PetCareApplicationDbContext dbContext) : IOrderRepository
    {

    }
}
