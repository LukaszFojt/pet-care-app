using PetCareApplication.Application.Contracts.Pet;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.Pet
{
    public class PetRequirementRepository(PetCareApplicationDbContext dbContext) : IPetRequirementRepository
    {

    }
}
