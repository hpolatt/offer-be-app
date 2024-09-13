using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Persistence.Configurations
{
    internal class QuoteItemConfiguration : IEntityTypeConfiguration<QuoteItem>
    {
        public void Configure(EntityTypeBuilder<QuoteItem> builder)
        {
            builder.HasKey(qi => qi.Id);

            builder.Property(qi => qi.Quantity)
                .IsRequired();

            builder.Property(qi => qi.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(qi => qi.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}

