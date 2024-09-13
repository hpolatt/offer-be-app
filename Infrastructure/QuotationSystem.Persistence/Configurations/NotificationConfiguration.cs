﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Persistence.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(n => n.IsRead)
                .IsRequired();

            // Foreign key relationship
            builder.HasOne(n => n.User)
                   .WithMany()
                   .HasForeignKey(n => n.UserId);
        }
    }
}

