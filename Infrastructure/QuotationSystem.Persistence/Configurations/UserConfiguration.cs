using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            // One-to-Many relationship
            builder.HasMany(u => u.Quotes)
                   .WithOne(q => q.User)
                   .HasForeignKey(q => q.UserId);
        }
    }
}

