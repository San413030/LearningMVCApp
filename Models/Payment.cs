using System.ComponentModel.DataAnnotations;

namespace LearningMVCApp.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentStatus { get; set; }

        public string? TransactionId { get; set; }

        public string? RazorpayOrderId { get; set; }

        public User User { get; set; } = null!;
    }
}
