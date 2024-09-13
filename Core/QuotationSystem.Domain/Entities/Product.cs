using System.ComponentModel.DataAnnotations.Schema;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("products")]
    public class Product : EntityBase, IEntityBase
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("price")]
        public decimal Price { get; set; }

        // One-to-Many: A product can be part of many quote items
        public ICollection<QuoteItem> QuoteItems { get; set; } = new List<QuoteItem>();

        // Parameterless constructor
        public Product() { }

        // Parameterized constructor
        public Product(string name, decimal price, string description = "")
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}

