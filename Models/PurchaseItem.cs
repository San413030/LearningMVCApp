using System.ComponentModel.DataAnnotations;

namespace LearningMVCApp.Models
{
    public class PurchaseItem
    {
        [Key]
        public int PurchaseItemId { get; set; }

        public int PurchaseId { get; set; }

        public int MasterCourseId { get; set; }

        public decimal Price { get; set; }

        public Purchase? Purchase { get; set; } 

        public MasterCourse? MasterCourse { get; set; }
    }
}
