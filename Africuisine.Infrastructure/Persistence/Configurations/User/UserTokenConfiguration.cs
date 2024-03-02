using Africuisine.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Infrastructure.Persistence.Configurations.Users
{
    internal class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {

            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            builder.Property(t => t.LoginProvider).HasMaxLength(255);
            builder.Property(t => t.Name).HasMaxLength(255);
            builder.ToTable("UserTokens");
        }
    }
}
