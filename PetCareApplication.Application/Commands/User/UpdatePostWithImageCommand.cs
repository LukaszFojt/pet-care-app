using MediatR;
using Microsoft.AspNetCore.Http;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Commands.User
{
    public class UpdatePostWithImageCommand : IRequest<PostEntity>
    {
        public int PostId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? UserId { get; set; }
        public IFormFile? ImageFile { get; set; }

        public UpdatePostWithImageCommand()
        {
        }
    }

    public class UpdatePostWithImageCommandHandler(IPostRepository postRepository) : IRequestHandler<UpdatePostWithImageCommand, PostEntity>
    {
        public async Task<PostEntity> Handle(UpdatePostWithImageCommand request, CancellationToken cancellationToken)
        {
            return await postRepository.UpdatePostWithImage(
                request.PostId, request?.Name, request?.Description, request?.Created, request?.Updated, request?.UserId, request?.ImageFile);
        }
    }
}
