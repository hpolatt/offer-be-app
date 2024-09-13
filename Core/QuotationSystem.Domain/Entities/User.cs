using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("users")]
    public class User : EntityBase, IEntityBase
    {

        [Column("username")]
        public string Username { get; set; } = string.Empty;
        
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("role")]
        public string Role { get; set; } = string.Empty; // 'admin', 'sales', 'customer'

        [Column("customer_id")]
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

