using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.DTO
{
    public class PromotionsDto
    {
        public string Name { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public double Discound { get; set; }
        public int Productwhith { get; set; }
    }
}
