using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string? AddressLine { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? City { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? State { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string? ZipCode { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? Country { get; set; }
    }
}
