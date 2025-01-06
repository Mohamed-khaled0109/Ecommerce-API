using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.DTO
{
    public class ProductWithPormotionsDto
    {
        [Required]
        public double Discound { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string UserId { get; set; }
        public List<string> promotionsName {  get; set; }=new List<string>();
    }
}
