using LearningMVCApp.Models;
using LearningMVCApp.Repository;
using LearningMVCApp.Data;


namespace LearningMVCApp.Service
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext cs;
        public CartService(ApplicationDbContext cs)
        {
            this.cs = cs;
        }

        public void AddToCart(int userId, int masterCourseId)
        {
            var cartItem = cs.CartItems
                .FirstOrDefault(c => c.UserId == userId && c.MasterCourseId == masterCourseId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = userId,
                    MasterCourseId = masterCourseId,
                    Quantity = 1,
                    AddedDate = DateTime.Now
                };

                cs.CartItems.Add(cartItem);
                cs.SaveChanges();
            }
        }

        public List<CartItem> GetCartItems()
        {
            var cartItems = cs.CartItems.ToList();
            return cartItems;
        }

        public void RemoveFromCart(int cartItemId)
        {
            var cartItem = cs.CartItems.Find(cartItemId);
            if (cartItem != null)
            {
                cs.CartItems.Remove(cartItem);
                cs.SaveChanges();
            }
        }

        public decimal GetCartTotal(int userId)
        {
            var cartItems = cs.CartItems.Where(c => c.UserId == userId).ToList();

            decimal total = 0;

            foreach (var item in cartItems)
            {
                total += cs.SubCourses.Where(s => s.MasterCourseId == item.MasterCourseId).Sum(s => s.Amount);
            }

            return total;
        }

        public void ClearCart(int userId)
        {
            var cartItems = cs.CartItems.Where(c => c.UserId == userId).ToList();
            cs.CartItems.RemoveRange(cartItems);
            cs.SaveChanges();
        }
    }
}
