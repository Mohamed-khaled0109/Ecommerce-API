using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
    public class Productes
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Descrption { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int stockQuantitu { get; set; }
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image must contain jpg or png ")]
        public string Imge { get; set; }
        
        public string? Video { get; set; }

        [ForeignKey("categore")]
        public int idCategores { get; set; }
        public virtual Categories categore { get; set; }

        [ForeignKey("shoppingcart")]
        public int idShopingCar { get; set; }
        public virtual ShoppingCart shoppingcart { get; set; }


        public virtual ICollection<ProductReview> productReviews { get; set; }
        public virtual ICollection<OrderDeetails> orderDeetails { get; set; }

        public virtual ICollection<ProductWithPormotions> productWithPormotions { get; set; }





    }
}
