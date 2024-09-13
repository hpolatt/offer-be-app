using System;
using System.ComponentModel.DataAnnotations;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    public class Notification : EntityBase, IEntityBase
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;

        // Parameterless constructor
        public Notification() { }

        // Parameterized constructor
        public Notification(int userId, string message)
        {
            UserId = userId;
            Message = message;
            IsRead = false;
        }
    }

}

