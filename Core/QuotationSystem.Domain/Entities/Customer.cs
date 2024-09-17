using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("customers")]
    public class Customer : EntityBase, IEntityBase
    {

        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("contact_person")]
        public string ContactPerson { get; set; } = string.Empty;
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
        [Column("company_name")]
        public string CompanyName { get; set; }
        [Column("address")]
        public string? Address { get; set; }

        // One-to-Many: A customer can have many quotes
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();

        // Parameterless constructor
        public Customer() { }

        // Parameterized constructor
        public Customer(string name, string contactPerson, string email, string? phoneNumber, string companyName, string address)
        {
            Name = name;
            ContactPerson = contactPerson;
            Email = email;
            PhoneNumber = phoneNumber;
            CompanyName = companyName;
            Address = address;
        }
    }
}

