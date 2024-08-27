using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAOnlineMart.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string? Description { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string? ImageUrl { get; set; }
    }
}
