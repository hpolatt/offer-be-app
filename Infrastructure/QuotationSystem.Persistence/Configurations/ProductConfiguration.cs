using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Configure Id to be auto-incrementing

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired();        

                builder.Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd(); // Configure Id to be auto-incrementing    

                builder.Property(p => p.UpdatedAt)
                .ValueGeneratedOnAdd(); // Configure Id to be auto-incrementing    
        }
    }
}

