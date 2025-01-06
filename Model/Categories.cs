using System.ComponentModel.DataAnnotations;

namespace Ecommerce_API.Model
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        

        public virtual ICollection<Productes> prod { get; set; }


    }
}
