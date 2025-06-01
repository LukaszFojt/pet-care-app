using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Queries.User
{
    public class GetPostsByUserIdQuery : IRequest<List<PostEntity>>
    {
        public string UserId { get; set; }

        public GetPostsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetPostsByUserIdQueryHandler(IPostRepository postRepository) : IRequestHandler<GetPostsByUserIdQuery, List<PostEntity>>
    {
        public async Task<List<PostEntity>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await postRepository.GetAllByUserId(request.UserId);
        }
    }
}
