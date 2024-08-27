using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? CardHolderName { get; set; }

        [Required]
        [CreditCard]
        public string? CardNumber { get; set; }

        [Required]
        [StringLength(5)]
        public string? ExpirationDate { get; set; }

        [Required]
        [StringLength(3)]
        public string? CVV { get; set; }
    }
}
