using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Models
{
    public class MasterCourse
    {
        [Key]
        public int MasterCourseId { get; set; }

        [Required]
        public string MasterCourseName { get; set; }

        public string Thumbnail { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }  = "Admin";
    }
}
