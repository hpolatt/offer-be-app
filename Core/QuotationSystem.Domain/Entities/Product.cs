using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    public class Product : EntityBase, IEntityBase
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

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

