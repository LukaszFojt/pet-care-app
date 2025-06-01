using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PetCareApplication.Application;
using PetCareApplication.Application.Contracts.Common;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Domain.Entities.Structure;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Infrastructure;
using PetCareApplication.Infrastructure.DbContexts;
using PetCareApplication.Infrastructure.Hubs;
using PetCareApplication.Infrastructure.Repositories.User;

namespace PetCareApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dodawanie us³ug do kontenera DI.
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();
            builder.Services.AddSignalR();

            // Authorization
            builder.Services.AddAuthorization(options =>
            {
                var policy = new AuthorizationPolicyBuilder(IdentityConstants.ApplicationScheme, IdentityConstants.BearerScheme)
                    .RequireAuthenticatedUser()
                    .Build();
                options.DefaultPolicy = policy;
            });

            builder.Services.AddAuthentication()
                .AddCookie(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);

            builder.Services.AddIdentityCore<UserEntity>()
                .AddEntityFrameworkStores<PetCareApplicationDbContext>()
                .AddApiEndpoints();

            // Services
            // Pet
            builder.Services.ConfigureApplicationServices<PetEntity>();
            builder.Services.ConfigureApplicationServices<PetRequirementEntity>();
            builder.Services.ConfigureApplicationServices<RequirementEntity>();
            // Structure
            builder.Services.ConfigureApplicationServices<ProductEntity>();
            builder.Services.ConfigureApplicationServices<ProductParameterEntity>();
            builder.Services.ConfigureApplicationServices<ParameterEntity>();
            // User
            builder.Services.ConfigureApplicationServices<PostEntity>();
            builder.Services.AddScoped<IFilterHandler<PostEntity>, PostFilterHandler>();
            builder.Services.ConfigureApplicationServices<UserInfoEntity>();
            builder.Services.ConfigureApplicationServices<ConditionEntity>();
            builder.Services.ConfigureApplicationServices<OrderEntity>();
            builder.Services.ConfigureApplicationServices<ChatMessageEntity>();
            builder.Services.ConfigureApplicationServices<ChatMessageRecipientEntity>();
            builder.Services.ConfigureApplicationServices<ConditionToUserTieEntity>();

            builder.Services.ConfigureServices(builder.Configuration);

            var app = builder.Build();

            // Konfiguracja CORS (Cross-Origin Resource Sharing).
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:5173")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .SetIsOriginAllowed(_ => true);
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints?.MapControllers();
                endpoints?.MapHub<ChatHub>("/chatHub");
            });

            app.MapIdentityApi<UserEntity>();

            app.Run();
        }
    }
}
