using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string? FirstName { get; set; }
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string? LastName { get; set; }
    }
}
