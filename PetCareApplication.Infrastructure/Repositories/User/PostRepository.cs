using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Application.Contracts.Common;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Application.Queries.Common;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.User
{
    public class PostRepository(PetCareApplicationDbContext dbContext) : IPostRepository
    {
        public async Task<List<PostEntity>> GetAllByUserId(string userId)
        {
            return await dbContext.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<PostEntity> AddPostWithImage(
            string name, string? description, DateTime? created, DateTime? updated, string userId, IFormFile imageFile)
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

            var post = new PostEntity
            {
                Name = name,
                Description = description,
                Created = created,
                Updated = updated,
                UserId = userId,
                ImagePath = $"/uploads/{fileName}"
            };

            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();

            return post;
        }

        public async Task<PostEntity> UpdatePostWithImage(
            int postId, string? name, string? description, DateTime? created, DateTime? updated, string? userId, IFormFile? imageFile)
        {
            var post = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == postId);

            if (post == null)
            {
                throw new Exception("Nie znaleziono postu o podanym ID.");
            }

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

            if (!string.IsNullOrEmpty(name)) post.Name = name;
            if (!string.IsNullOrEmpty(description)) post.Description = description;
            if (created.HasValue) post.Created = created;
            if (updated.HasValue) post.Updated = updated;
            if (!string.IsNullOrEmpty(userId)) post.UserId = userId;

            dbContext.Posts.Update(post);
            await dbContext.SaveChangesAsync();

            return post;
        }
    }

    public class PostFilterHandler : IFilterHandler<PostEntity>
    {
        public async Task<List<PostEntity>> ApplyFiltersAsync(
            IQueryable<PostEntity> query,
            List<FilterParameter> filters,
            IQueryable<ConditionToUserTieEntity> conditionToUserTiesQuery)
        {
            bool requiresUserTies = filters.Any(f =>
                f.FilterName == PostFilters.HasAnyService ||
                f.FilterName == PostFilters.HasAnyAnimal ||
                f.FilterName == PostFilters.HasAnyCity);

            if (!requiresUserTies)
            {
                foreach (var filter in filters)
                {
                    switch (filter.FilterName)
                    {
                        case PostFilters.ContainsName:
                            var name = filter.FilterValue?.ToString() ?? string.Empty;
                            query = query.Where(x => EF.Functions.Like(x.Name, $"%{name}%"));
                            break;

                        case PostFilters.DateStart:
                            if (DateTime.TryParse(filter.FilterValue?.ToString(), out var dateStart))
                            {
                                query = query.Where(x => x.Created >= dateStart);
                            }
                            break;

                        case PostFilters.DateEnd:
                            if (DateTime.TryParse(filter.FilterValue?.ToString(), out var dateEnd))
                            {
                                query = query.Where(x => x.Created <= dateEnd);
                            }
                            break;
                    }
                }

                return await query.ToListAsync();
            }

            var posts = await query.ToListAsync();
            var conditionTies = await conditionToUserTiesQuery.ToListAsync();

            foreach (var filter in filters)
            {
                switch (filter.FilterName)
                {
                    case PostFilters.ContainsName:
                        var name = filter.FilterValue?.ToString() ?? string.Empty;
                        posts = posts
                            .Where(x => x.Name != null && x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                        break;

                    case PostFilters.DateStart:
                        if (DateTime.TryParse(filter.FilterValue?.ToString(), out var dateStart))
                        {
                            posts = posts.Where(x => x.Created >= dateStart).ToList();
                        }
                        break;

                    case PostFilters.DateEnd:
                        if (DateTime.TryParse(filter.FilterValue?.ToString(), out var dateEnd))
                        {
                            posts = posts.Where(x => x.Created <= dateEnd).ToList();
                        }
                        break;

                    case PostFilters.HasAnyService:
                        var service = filter.FilterValue?.ToString() ?? string.Empty;
                        posts = posts.Where(post =>
                            conditionTies.Any(t =>
                                t.UserId == post.UserId &&
                                t.Name == "Services" &&
                                !string.IsNullOrEmpty(t.Description) &&
                                t.Description == service
                            )).ToList();
                        break;

                    case PostFilters.HasAnyAnimal:
                        var animal = filter.FilterValue?.ToString() ?? string.Empty;
                        posts = posts.Where(post =>
                            conditionTies.Any(t =>
                                t.UserId == post.UserId &&
                                t.Name == "Animals" &&
                                !string.IsNullOrEmpty(t.Description) &&
                                t.Description == animal
                            )).ToList();
                        break;

                    case PostFilters.HasAnyCity:
                        var city = filter.FilterValue?.ToString() ?? string.Empty;
                        posts = posts.Where(post =>
                            conditionTies.Any(t =>
                                t.UserId == post.UserId &&
                                t.Name == "Cities" &&
                                !string.IsNullOrEmpty(t.Description) &&
                                t.Description == city
                            )).ToList();
                        break;
                }
            }

            return posts;
        }
    }
}
