using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int Quntity { get; set; }
        [ForeignKey("app")]
        public string UserId { get; set; }
        public virtual ApplcationUser app { get; set; }
        public virtual ICollection<Productes> productes { get; set; }
        [ForeignKey("order")]
        public int idorder { get; set; }
        public virtual Orders order { get; set; }


    }
}
