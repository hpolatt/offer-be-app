using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("quote_items")]
    public class QuoteItem : EntityBase, IEntityBase
    {
        [Column("quote_id")]
        public int QuoteId { get; set; }
        public Quote? Quote { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Column("total_price")]
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