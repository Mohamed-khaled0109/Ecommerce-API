using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
    public class Promotions
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public double Discound { get; set; }

        [ForeignKey("Pormotions")]
        public int Productwhith { get; set; }
        public virtual ProductWithPormotions Pormotions { get; set; }
    }
}
