using System;
using System.ComponentModel.DataAnnotations;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    public class Customer : EntityBase, IEntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // One-to-Many: A customer can have many quotes
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();

        // Parameterless constructor
        public Customer() { }

        // Parameterized constructor
        public Customer(string name, string contactPerson, string email, string phoneNumber, string companyName, string address)
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

