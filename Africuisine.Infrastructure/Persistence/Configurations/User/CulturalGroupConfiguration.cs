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
    public class CulturalGroupConfiguration : IEntityTypeConfiguration<CulturalGroup>
    {
        public void Configure(EntityTypeBuilder<CulturalGroup> builder)
        {
           builder.HasKey(c => c.Id);
           builder.ToTable("CulturalGroups");
           builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
           builder.HasIndex(u => u.Name).HasDatabaseName("IX_CulturalGroups_Name").IsUnique();
        }
    }
}
