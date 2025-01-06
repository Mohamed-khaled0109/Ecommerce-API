using Ecommerce_API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.DTO
{
    public class ProductesDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descrption { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int stockQuantitu { get; set; }
        [Required]
        public string Imge { get; set; }
        public string Video { get; set; }
        [Required]
        public int idCategores { get; set; }
        [Required]
        public int idShopingCar { get; set; }

        public List<string> productReviews {  get; set; }=new List<string>();
        public List<string> orderDeetails { get; set; } = new List<string>();
        public List<string> productWithPormotions { get; set; } = new List<string>();
    }
}
