using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Application.Contracts.Pet;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.Pet
{
    public class PetRepository(PetCareApplicationDbContext dbContext) : IPetRepository
    {
        public async Task<List<PetEntity>> GetAllByUserId(string userId)
        {
            return await dbContext.Pets.Where(p => p.UserId == userId).ToListAsync();
        }
        public async Task<PetEntity> AddPetWithImage(
            string name, string? description, float age, Size size, Sex sex,
            string userId, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Brak pliku obrazu.");
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            var pet = new PetEntity
            {
                Name = name,
                Description = description,
                Age = age,
                Size = size,
                Sex = sex,
                UserId = userId,
                ImagePath = $"/uploads/{fileName}"
            };

            dbContext.Pets.Add(pet);
            await dbContext.SaveChangesAsync();

            return pet;
        }

        public async Task<PetEntity> UpdatePetWithImage(
            int petId, string? name, string? description, float? age, Size? size, Sex? sex,
            string? userId, IFormFile? imageFile)
        {
            var pet = await dbContext.Pets.FirstOrDefaultAsync(x => x.Id == petId);

            if (pet == null)
            {
                throw new Exception("Nie znaleziono zwierzaka o podanym ID.");
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                pet.ImagePath = $"/uploads/{fileName}";
            }

            if (!string.IsNullOrEmpty(name)) pet.Name = name;
            if (!string.IsNullOrEmpty(description)) pet.Description = description;
            if (age.HasValue) pet.Age = age.Value;
            if (size.HasValue) pet.Size = size.Value;
            if (sex.HasValue) pet.Sex = sex.Value;
            if (!string.IsNullOrEmpty(userId)) pet.UserId = userId;

            dbContext.Pets.Update(pet);
            await dbContext.SaveChangesAsync();

            return pet;
        }
    }
}
