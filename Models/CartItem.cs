namespace LearningMVCApp.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int MasterCourseId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
