using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? CardHolderName { get; set; }

        [Required]
        [CreditCard]
        public string? CardNumber { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string? ExpirationDate { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string? CVV { get; set; }
    }
}
