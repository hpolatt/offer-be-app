using System;
using Microsoft.EntityFrameworkCore;
using QuotationSystem.Domain.Entities;
using QuotationSystem.Persistence.Configurations;
using System.Reflection;

namespace QuotationSystem.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }
        public DbSet<Approval> Approvals { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public AppDbContext()
        {
        }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}