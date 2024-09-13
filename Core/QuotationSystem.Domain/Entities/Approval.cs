using System;
using System.ComponentModel.DataAnnotations;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Domain.Entities
{
    public class Approval : EntityBase, IEntityBase
    {
     
        public int QuoteId { get; set; }
        public Quote? Quote { get; set; }
                
        public  int ApproverId { get; set; }
        public User? Approver { get; set; }
                
        public  string ApprovalStatus { get; set; } = "pending"; // 'pending', 'approved', 'rejected'

        public DateTime? ApprovalDate { get; set; }

        public string Comments { get; set; } = string.Empty;

        // Parameterless constructor
        public Approval() { }
	
        // Parameterized constructor
        public Approval(int quoteId, int approverId, string approvalStatus, string comments = "")
        {
            QuoteId = quoteId;
            ApproverId = approverId;
            ApprovalStatus = approvalStatus;
            Comments = comments;
        }
    }
}

