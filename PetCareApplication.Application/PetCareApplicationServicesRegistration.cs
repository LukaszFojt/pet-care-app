using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PetCareApplication.Application.Commands.Common;
using PetCareApplication.Application.Commands.Pet;
using PetCareApplication.Application.Commands.User;
using PetCareApplication.Application.Queries.Common;
using PetCareApplication.Application.Queries.Pet;
using PetCareApplication.Application.Queries.User;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Domain.Entities.User;
using System.Reflection;

namespace PetCareApplication.Application
{
    public static class PetCareApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices<T>(this IServiceCollection services) where T : class
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IRequestHandler<GetAllEntitiesQuery<T>, List<T>>), typeof(GetAllEntitiesQueryHandler<T>));
            services.AddScoped(typeof(IRequestHandler<GetEntityByIdQuery<T>, T>), typeof(GetEntityByIdQueryHandler<T>));
            services.AddScoped(typeof(IRequestHandler<GetTopEntitiesQuery<T>, List<T>>), typeof(GetTopEntitiesQueryHandler<T>));
            services.AddScoped(typeof(IRequestHandler<GetBotEntitiesQuery<T>, List<T>>), typeof(GetBotEntitiesQueryHandler<T>));
            services.AddScoped(typeof(IRequestHandler<AddEntityCommand<T>, T>), typeof(AddEntityCommandHandler<T>));
            services.AddScoped(typeof(IRequestHandler<UpdateEntityCommand<T>, T>), typeof(UpdateEntityCommandHandler<T>));
            services.AddScoped(typeof(IRequestHandler<DeleteEntityCommand<T>, Unit>), typeof(DeleteEntityCommandHandler<T>));
            services.AddScoped(typeof(IRequestHandler<GetFilteredEntitiesQuery<T>, List<T>>), typeof(GetFilteredEntitiesQueryHandler<T>));

            services.AddScoped<IRequestHandler<GetCurrentUserQuery, UserEntity>, GetCurrentUserQueryHandler>();
            services.AddScoped<IRequestHandler<LogoutUserCommand, bool>, LogoutUserCommandHandler>();
            services.AddScoped<IRequestHandler<GetPostsByUserIdQuery, List<PostEntity>>, GetPostsByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetPetsByUserIdQuery, List<PetEntity>>, GetPetsByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<AddPostWithImageCommand, PostEntity>, AddPostWithImageCommandHandler>();
            services.AddScoped<IRequestHandler<AddPetWithImageCommand, PetEntity>, AddPetWithImageCommandHandler>();
            services.AddScoped<IRequestHandler<GetUserInfoByUserIdQuery, UserInfoEntity>, GetUserInfoByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetMessagesByUserIdQuery, List<ChatMessageEntity>>, GetMessagesByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserInfoByUserIdQuery, UserInfoEntity>, GetUserInfoByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<UpdateUserInfoByUserIdCommand, UserInfoEntity>, UpdateUserInfoByUserIdCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterUserAndNotifyCommand, bool>, RegisterUserAndNotifyCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePetWithImageCommand, PetEntity>, UpdatePetWithImageCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePostWithImageCommand, PostEntity>, UpdatePostWithImageCommandHandler>();
            services.AddScoped<IRequestHandler<GetMessagesBetweenUsersQuery, List<ChatMessageEntity>>, GetMessagesBetweenUsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetOrdersByUserIdQuery, List<OrderEntity>>, GetOrdersByUserIdQueryHandler>();

            return services;
        }
    }
}
