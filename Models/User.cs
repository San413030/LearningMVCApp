using System.ComponentModel.DataAnnotations;

namespace LearningMVCApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
