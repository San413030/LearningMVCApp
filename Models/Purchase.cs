using System.ComponentModel.DataAnnotations;

namespace LearningMVCApp.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        public int UserId { get; set; }

        public int PaymentId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public User? User { get; set; }

        public Payment? Payment { get; set; } 
    }
}
