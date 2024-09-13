using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Persistence.Configurations
{
    internal class ApprovalConfiguration : IEntityTypeConfiguration<Approval>
    {
        public void Configure(EntityTypeBuilder<Approval> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Comments)
                .HasMaxLength(500);

            // Foreign key relationships
            builder.HasOne(a => a.Quote)
                   .WithMany()
                   .HasForeignKey(a => a.QuoteId);

            builder.HasOne(a => a.Approver)
                   .WithMany()
                   .HasForeignKey(a => a.ApproverId);
        }
    }
}

