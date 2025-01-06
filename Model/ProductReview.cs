using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
    public class ProductReview
    {

        public int Id { get; set; }

        public string Comment { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "The rating must be between 0 and 5.")]
        public double Rating { get; set; }
        
        public DateTime ReviewDate { get; set; }


        [ForeignKey("producte")]
        public int ProductId { get; set; }
        public virtual Productes producte { get; set; }

        [ForeignKey("applcationuser")]
        public string Userid { get; set; }
        public virtual ApplcationUser applcationuser { get; set; }

    }
}
