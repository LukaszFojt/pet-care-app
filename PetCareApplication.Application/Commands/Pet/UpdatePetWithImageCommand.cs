using MediatR;
using Microsoft.AspNetCore.Http;
using PetCareApplication.Application.Contracts.Pet;
using PetCareApplication.Domain.Entities.Pet;

namespace PetCareApplication.Application.Commands.Pet
{
    public class UpdatePetWithImageCommand : IRequest<PetEntity>
    {
        public int PetId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Age { get; set; }
        public Size? Size { get; set; }
        public Sex? Sex { get; set; }
        public string? UserId { get; set; }
        public IFormFile? ImageFile { get; set; }

        public UpdatePetWithImageCommand()
        {
        }
    }

    public class UpdatePetWithImageCommandHandler(IPetRepository petRepository) : IRequestHandler<UpdatePetWithImageCommand, PetEntity>
    {
        public async Task<PetEntity> Handle(UpdatePetWithImageCommand request, CancellationToken cancellationToken)
        {
            return await petRepository.UpdatePetWithImage(
                request.PetId, request?.Name, request?.Description, request?.Age, request?.Size, request?.Sex, request?.UserId, request?.ImageFile);
        }
    }
}
