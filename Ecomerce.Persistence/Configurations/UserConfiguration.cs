using Ecomerce.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomerce.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.Salt)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("NOW()");
        }
    }
}
