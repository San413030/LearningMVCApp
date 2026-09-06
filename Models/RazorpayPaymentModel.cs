namespace LearningMVCApp.Models
{
    public class RazorpayPaymentModel
    {
        public string RazorpayPaymentId { get; set; } = null!;

        public string RazorpayOrderId { get; set; } = null!;

        public string RazorpaySignature { get; set; } = null!;
    }
}