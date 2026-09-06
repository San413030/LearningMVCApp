using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningMVCApp.Models
{
    public class SubCourse
    {
        [Key]
        public int SubCourseId { get; set; }
        [ForeignKey("MasterCourse")]
        public int MasterCourseId { get; set; }
        public string? SubCourseName { get; set; }
        public string? Thumbnail { get; set; }
        public string? Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
