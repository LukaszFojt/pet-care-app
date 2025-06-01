using MediatR;
using Microsoft.AspNetCore.Http;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Commands.User
{
    public class AddPostWithImageCommand : IRequest<PostEntity>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string UserId { get; set; }
        public IFormFile ImageFile { get; set; }

        public AddPostWithImageCommand()
        {
        }
    }

    public class AddPostWithImageCommandHandler(IPostRepository postRepository) : IRequestHandler<AddPostWithImageCommand, PostEntity>
    {
        public async Task<PostEntity> Handle(AddPostWithImageCommand request, CancellationToken cancellationToken)
        {
            return await postRepository.AddPostWithImage(
                request.Name, request.Description, request.Created, request.Updated, request.UserId, request.ImageFile);
        }
    }
}
