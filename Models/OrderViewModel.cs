namespace SAOnlineMart.Models
{
    public class OrderViewModel
    {
        public List<OrderProduct> CartItems { get; set; } = new List<OrderProduct>();
        public ShippingAddress ShippingAddress { get; set; } = new ShippingAddress();
        public Payment Payment { get; set; } = new Payment();
    }
}