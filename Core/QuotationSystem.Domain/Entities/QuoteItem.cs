using System;
using System.ComponentModel.DataAnnotations;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    public class QuoteItem : EntityBase, IEntityBase
    {
        public int QuoteId { get; set; }
        public Quote? Quote { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; } // Calculated as Quantity * UnitPrice

        // Parameterless constructor
        public QuoteItem() { }

        // Parameterized constructor
        public QuoteItem(int quoteId, int productId, int quantity, decimal unitPrice)
        {
            QuoteId = quoteId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = quantity * unitPrice;
        }
    }
}