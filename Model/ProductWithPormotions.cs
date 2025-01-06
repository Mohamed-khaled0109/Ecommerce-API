using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
    public class ProductWithPormotions
    {
        public int Id { get; set; }
        [Required]
        public double Discound { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }



        [ForeignKey("productes")]
        public int ProductId { get; set; }
        public virtual Productes productes { get; set; }


        public virtual ICollection<Promotions> promotions { get; set; }

        [ForeignKey("user")]
        public string UserId { get; set; }
        public virtual ApplcationUser user { get; set; }



    }
}
