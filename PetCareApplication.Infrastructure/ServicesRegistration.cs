using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetCareApplication.Application.Contracts.Common;
using PetCareApplication.Application.Contracts.Pet;
using PetCareApplication.Application.Contracts.Structure;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Infrastructure.Configurations.Profiles;
using PetCareApplication.Infrastructure.DbContexts;
using PetCareApplication.Infrastructure.Repositories.Common;
using PetCareApplication.Infrastructure.Repositories.Pet;
using PetCareApplication.Infrastructure.Repositories.Structure;
using PetCareApplication.Infrastructure.Repositories.User;
using PetCareApplication.Infrastructure.Services;

namespace PetCareApplication.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PetCareApplicationDbContext>(options =>
            options.UseSqlServer(
                    configuration.GetConnectionString("PetCareDb")));

            //Services
            services.AddHttpClient<IEmailNotifierService, EmailNotifierService>();

            // Profiles
            services.AddAutoMapper(typeof(UserInfoProfile));

            // Common
            services.AddScoped(typeof(ICommonCrudRepository<>), typeof(CommonCrudRepository<>));

            // Pet
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IRequirementRepository, RequirementRepository>();
            services.AddScoped<IPetRequirementRepository, PetRequirementRepository>();

            // Structure
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();
            services.AddScoped<IProductParameterRepository, ProductParameterRepository>();

            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IConditionRepository, ConditionRepository>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            services.AddScoped<IChatMessageRecipientRepository, ChatMessageRecipientRepository>();
            services.AddScoped<IConditionToUserTieRepository, ConditionToUserTieRepository>();

            return services;
        }
    }
}
