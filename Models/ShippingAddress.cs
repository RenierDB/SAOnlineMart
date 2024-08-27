using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? AddressLine { get; set; }

        [Required]
        [StringLength(100)]
        public string? City { get; set; }

        [Required]
        [StringLength(100)]
        public string? State { get; set; }

        [Required]
        [StringLength(10)]
        public string? ZipCode { get; set; }

        [Required]
        [StringLength(100)]
        public string? Country { get; set; }
    }
}
