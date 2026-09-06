namespace LearningMVCApp.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; } = null!;
        public List<MasterCourse> MasterCourses { get; set; } = new List<MasterCourse>();
        public decimal CartTotal { get; set; }
    }
}
