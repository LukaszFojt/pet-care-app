using Microsoft.AspNetCore.Http;
using PetCareApplication.Domain.Entities.Pet;

namespace PetCareApplication.Application.Contracts.Pet
{
    public interface IPetRepository
    {
        Task<List<PetEntity>> GetAllByUserId(string userId);
        Task<PetEntity> AddPetWithImage(string name, string description, float age, Size size, Sex sex, string userId, IFormFile imageFile);
        Task<PetEntity> UpdatePetWithImage(int petId, string? name, string? description, float? age, Size? size, Sex? sex, string? userId, IFormFile? imageFile);
    }
}
