using LearningMVCApp.Models;

namespace LearningMVCApp.Repository
{
    public interface ICartService
    {
        void AddToCart(int userId, int masterCourseId);
        List<CartItem> GetCartItems();
        void RemoveFromCart(int cartItemId);
        decimal GetCartTotal(int userId);
        void ClearCart(int userId);
    }
}
