using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAOnlineMart.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public ICollection<OrderProduct>? Products { get; set; }
        [Required]
        public ShippingAddress? ShippingAddress { get; set; }
        [Required]
        public Payment? Payment { get; set; }
    }
}
