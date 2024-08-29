using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    public interface IBaseProduct
    {
        int Id { get; set; }
        string? Name { get; set; }
        decimal Price { get; set; }
    }

    public interface IProduct
    {
        string? Description { get; set; }
        string? ImageUrl { get; set; }
    }

    public interface IOrderProduct
    {
        int Quantity { get; set; }
    }

    public class BaseProduct : IBaseProduct
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        [Range(1, 9999999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
