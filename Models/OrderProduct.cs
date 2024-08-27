using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SAOnlineMart.Models;

namespace SAOnlineMart.Models
{
    public class OrderProduct : BaseProduct, IOrderProduct
    {
        [Required]
        public int Quantity { get; set; }
    }
}
