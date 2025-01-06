using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
    public class OrderDeetails
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("orders")]
        public int OrderId { get; set; }
        public virtual Orders orders { get; set; }
        [ForeignKey("products")]
        public int prouductid { get; set; }
        public virtual Productes products { get; set; }

    }
}
