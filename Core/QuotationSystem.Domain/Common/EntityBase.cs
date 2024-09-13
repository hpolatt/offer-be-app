using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuotationSystem.Domain.Common
{
    public class EntityBase : IEntityBase
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}

