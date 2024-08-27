using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SAOnlineMart.Models;

namespace SAOnlineMart.Models
{
    public class Product : BaseProduct, IProduct
    {
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string? Description { get; set; }
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string? ImageUrl { get; set; }
    }
}
