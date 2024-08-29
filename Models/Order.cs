using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SAOnlineMart.Models;

namespace SAOnlineMart.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime OrderDate { get; set; }

        public List<Product>? Products { get; set; } = default!;

        [Required]
        public ShippingAddress? ShippingAddress { get; set; }
        
        [Required]
        public Payment? Payment { get; set; }
    }
}
