using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("quotes")]
    public class Quote : EntityBase, IEntityBase
    {
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Column("status")]
        public string Status { get; set; } = "draft"; // 'draft', 'submitted', 'approved', 'rejected'

        [Column("total_price")]
        public double TotalPrice { get; set; }

        // One-to-Many: A quote can have many quote items
        public ICollection<QuoteItem> QuoteItems { get; set; } = new List<QuoteItem>();

        // Parameterless constructor
        public Quote() { }

        // Parameterized constructor
        public Quote(int customerId, int userId, string status, double totalPrice)
        {
            CustomerId = customerId;
            UserId = userId;
            Status = status;
            TotalPrice = totalPrice;
        }
    }
}

