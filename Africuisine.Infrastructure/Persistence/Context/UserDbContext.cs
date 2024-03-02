using Africuisine.Domain.Entities.User;
using Africuisine.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure.Persistence.Context
{
    public class UserDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<CulturalGroup> CulturalGroups { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureUserEntityTypeConfiguration();
            base.OnModelCreating(builder);
        }
    }
}
