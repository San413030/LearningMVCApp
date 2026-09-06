using System.ComponentModel.DataAnnotations;

namespace LearningMVCApp.Models
{
    public class MasterCourse
    {
        [Key]
        public int MasterCourseId { get; set; }
        public string? MasterCourseName { get; set; }
        public string? Thumbnail { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
