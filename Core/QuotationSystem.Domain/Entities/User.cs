using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("users")]
    public class User : IdentityUser<Guid>
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("fullname")]
        public string FullName { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

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

        public User(string passwordHash, string email, string role, int? customerId, string fullName)
        {
            PasswordHash = passwordHash;
            Email = email;
            Role = role;
            CustomerId = customerId;
            FullName = fullName;
        }
    }
}

