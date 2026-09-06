using LearningMVCApp.Models;
using LearningMVCApp.Repository;
using LearningMVCApp.Data;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;

namespace LearningMVCApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cs;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext db;

        public CartController(
            ICartService cs,
            IConfiguration configuration,
            ApplicationDbContext db)
        {
            this.cs = cs;
            this.configuration = configuration;
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = new CartViewModel
            {
                CartItems = cs.GetCartItems(),
                MasterCourses = db.MasterCourses.ToList(),
                CartTotal = cs.GetCartTotal(1)
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            cs.RemoveFromCart(cartItemId);

            TempData["SuccessMessage"] = "Item Removed Successfully!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddToCart(int userId, int masterCourseId)
        {
            cs.AddToCart(userId, masterCourseId);

            TempData["SuccessMessage"] = "Item Added Successfully!";

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Buy()
        {
            decimal amount = cs.GetCartTotal(1);

            string keyId = configuration["Razorpay:KeyId"];
            string keySecret = configuration["Razorpay:KeySecret"];

            RazorpayClient client =
                new RazorpayClient(keyId, keySecret);

            var options = new Dictionary<string, object>
            {
                { "amount", amount * 100 },
                { "currency", "INR" },
                { "receipt", "order_receipt_123" },
                { "payment_capture", 1 }
            };

            Razorpay.Api.Order order =
                client.Order.Create(options);

            ViewBag.KeyId = keyId;
            ViewBag.OrderId = order["id"].ToString();
            ViewBag.Amount = amount * 100;
            ViewBag.AmountInRupees = amount;

            return View("Payment");
        }



        [HttpPost]
        public IActionResult PaymentSuccess(
            [FromBody] RazorpayPaymentModel payment)
        {
            var options = new Dictionary<string, string>();

            options.Add(
                "razorpay_order_id",
                payment.RazorpayOrderId);

            options.Add(
                "razorpay_payment_id",
                payment.RazorpayPaymentId);

            options.Add(
                "razorpay_signature",
                payment.RazorpaySignature);

            Utils.verifyPaymentSignature(options);


            decimal amount = cs.GetCartTotal(1);


            LearningMVCApp.Models.Payment paymentData =   new LearningMVCApp.Models.Payment
                {
                    UserId = 1,
                    Amount = amount,
                    PaymentDate = DateTime.Now,
                    PaymentStatus = "Success",
                    TransactionId = payment.RazorpayPaymentId,
                    RazorpayOrderId = payment.RazorpayOrderId
                };

            db.Payments.Add(paymentData);
            db.SaveChanges();


            Purchase purchase = new Purchase
            {
                UserId = 1,
                PaymentId = paymentData.PaymentId,
                PurchaseDate = DateTime.Now
            };

            db.Purchases.Add(purchase);
            db.SaveChanges();

            var cartItems = cs.GetCartItems();

            foreach (var item in cartItems)
            {
                PurchaseItem purchaseItem = new PurchaseItem
                {
                    PurchaseId = purchase.PurchaseId,
                    MasterCourseId = item.MasterCourseId,
                    Price = cs.GetCartTotal(1)
                };

                db.PurchaseItems.Add(purchaseItem);
            }

            db.SaveChanges();

            cs.ClearCart(1);

            TempData["SuccessMessage"] = "Purchased Successfully!";

            return RedirectToAction("Index");
        }
    }
}