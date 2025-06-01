using Microsoft.AspNetCore.Http;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Contracts.User
{
    public interface IPostRepository
    {
        Task<List<PostEntity>> GetAllByUserId(string userId);
        Task<PostEntity> AddPostWithImage(string name, string? description, DateTime? created, DateTime? updated, string userId, IFormFile imageFile);
        Task<PostEntity> UpdatePostWithImage(int postId, string? name, string? description, DateTime? created, DateTime? updated, string? userId, IFormFile? imageFile);
    }

    public static class PostFilters
    {
        public const string ContainsName = "ContainsName";
        public const string DateStart = "DateStart";
        public const string DateEnd = "DateEnd";
        public const string HasAnyService = "HasAnyService";
        public const string HasAnyAnimal = "HasAnyAnimal";
        public const string HasAnyCity = "HasAnyCity";
    }
}
