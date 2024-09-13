using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Persistence.Configurations {
	internal class QuoteConfiguration : IEntityTypeConfiguration<Quote> {
		public void Configure (EntityTypeBuilder<Quote> builder)
		{
			builder.HasKey (q => q.Id);

			builder.Property (q => q.Status)
			    .IsRequired ()
			    .HasMaxLength (20);	
			    

			// One-to-Many relationship with QuoteItems
			builder.HasMany (q => q.QuoteItems)
			       .WithOne (qi => qi.Quote)
			       .HasForeignKey (qi => qi.QuoteId);
		}
	}
}
