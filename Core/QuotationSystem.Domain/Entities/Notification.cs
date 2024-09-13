using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("notifications")]
    public class Notification : EntityBase, IEntityBase
    {
        [Column("user_id")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Column("message")]
        public string Message { get; set; } = string.Empty;

        [Column("is_read")]
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

