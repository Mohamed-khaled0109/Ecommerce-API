using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_API.DTO
{
    public class ProductReviewDto
    {
        
        public string Comment { get; set; }
        [Range(0, 5, ErrorMessage = "The rating must be between 0 and 5.")]
        [Required]
        public double Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string Userid { get; set; }

    }
}
