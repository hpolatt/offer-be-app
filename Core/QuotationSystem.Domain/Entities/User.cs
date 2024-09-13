using System;
using System.ComponentModel.DataAnnotations;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    public class User : EntityBase, IEntityBase
    {
        public string Username { get; set; } = string.Empty;
        
        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty; // 'admin', 'sales', 'customer'

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // One-to-Many: A user can create many quotes
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();

        // Parameterless constructor
        public User() { }

        // Parameterized constructor
        public User(string username, string passwordHash, string email, string role, int? customerId = null)
        {
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            Role = role;
            CustomerId = customerId;
        }
    }
}

