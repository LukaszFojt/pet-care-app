using MediatR;
using Microsoft.AspNetCore.Http;
using PetCareApplication.Application.Contracts.Pet;
using PetCareApplication.Domain.Entities.Pet;

namespace PetCareApplication.Application.Commands.Pet
{
    public class AddPetWithImageCommand : IRequest<PetEntity>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Age { get; set; }
        public Size Size { get; set; }
        public Sex Sex { get; set; }
        public string UserId { get; set; }
        public IFormFile ImageFile { get; set; }

        public AddPetWithImageCommand()
        {
        }
    }

    public class AddPetWithImageCommandHandler(IPetRepository petRepository) : IRequestHandler<AddPetWithImageCommand, PetEntity>
    {
        public async Task<PetEntity> Handle(AddPetWithImageCommand request, CancellationToken cancellationToken)
        {
            return await petRepository.AddPetWithImage(
                request.Name, request.Description, request.Age, request.Size, request.Sex, request.UserId, request.ImageFile);
        }
    }
}
