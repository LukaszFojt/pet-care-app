using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Domain.Entities.Structure;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Infrastructure.DbContexts
{
    public class PetCareApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public PetCareApplicationDbContext(DbContextOptions<PetCareApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetCareApplicationDbContext).Assembly);

            // Auth
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "auth");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "auth");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "auth");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "auth");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "auth");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "auth");
        }

        #region Pet
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<RequirementEntity> Requirements { get; set; }
        public DbSet<PetRequirementEntity> PetsRequirements { get; set; }
        #endregion

        #region Structure
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ParameterEntity> Parameters { get; set; }
        public DbSet<ProductParameterEntity> ProductParameters { get; set; }
        #endregion

        #region User
        public DbSet<UserInfoEntity> UserInfos { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ConditionToUserTieEntity> ConditionToUserTies { get; set; }
        public DbSet<ConditionEntity> Conditions { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ChatMessageEntity> ChatMessages { get; set; }
        public DbSet<ChatMessageRecipientEntity> ChatMessageRecipients { get; set; }
        #endregion
    }
}
