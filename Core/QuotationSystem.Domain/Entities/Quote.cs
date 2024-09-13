using System;
using System.ComponentModel.DataAnnotations;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    public class Quote : EntityBase, IEntityBase
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string Status { get; set; } = "draft"; // 'draft', 'submitted', 'approved', 'rejected'

        public decimal TotalPrice { get; set; }

        // One-to-Many: A quote can have many quote items
        public ICollection<QuoteItem> QuoteItems { get; set; } = new List<QuoteItem>();

        // Parameterless constructor
        public Quote() { }

        // Parameterized constructor
        public Quote(int customerId, int userId, string status, decimal totalPrice)
        {
            CustomerId = customerId;
            UserId = userId;
            Status = status;
            TotalPrice = totalPrice;
        }
    }
}

