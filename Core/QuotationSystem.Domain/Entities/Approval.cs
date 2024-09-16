using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    [Table("approvals")]
    public class Approval : EntityBase, IEntityBase
    {
     
        [Column("quote_id")]
        public int QuoteId { get; set; }
        public Quote? Quote { get; set; }
                
        [Column("approver_id")]
        public  Guid ApproverId { get; set; }
        public User? Approver { get; set; }
                
        [Column("approval_status")]
        public  string ApprovalStatus { get; set; } = "pending"; // 'pending', 'approved', 'rejected'

        [Column("approval_date")]
        public DateTime? ApprovalDate { get; set; }

        [Column("comments")]
        public string Comments { get; set; } = string.Empty;

        // Parameterless constructor
        public Approval() { }
	
        // Parameterized constructor
        public Approval(int quoteId, Guid approverId, string approvalStatus, string comments = "")
        {
            QuoteId = quoteId;
            ApproverId = approverId;
            ApprovalStatus = approvalStatus;
            Comments = comments;
        }
    }
}

