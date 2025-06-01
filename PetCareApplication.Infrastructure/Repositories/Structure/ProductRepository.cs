using PetCareApplication.Application.Contracts.Structure;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.Structure
{
    public class ProductRepository(PetCareApplicationDbContext dbContext) : IProductRepository
    {

    }
}
