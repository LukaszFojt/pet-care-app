using MediatR;
using PetCareApplication.Application.Contracts.Pet;
using PetCareApplication.Domain.Entities.Pet;

namespace PetCareApplication.Application.Queries.Pet
{
    public class GetPetsByUserIdQuery : IRequest<List<PetEntity>>
    {
        public string UserId { get; set; }

        public GetPetsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetPetsByUserIdQueryHandler(IPetRepository petRepository) : IRequestHandler<GetPetsByUserIdQuery, List<PetEntity>>
    {
        public async Task<List<PetEntity>> Handle(GetPetsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await petRepository.GetAllByUserId(request.UserId);
        }
    }
}
