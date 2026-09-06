using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPlatform.Models
{
    public class SubCourse
    {
        [Key]
        public int SubCourseId { get; set; }

        [ForeignKey("MasterCourse")]
        public int MasterCourseId { get; set; }

        [Required]
        public string SubCourseName { get; set; }

        public string Thumbnail { get; set; }

        [Required]
        public string Status { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = "Admin";

        public MasterCourse MasterCourse { get; set; }

    }
}
