using Ecommerce_API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.DTO
{
    public class OrderDeetailsDto
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int OrderId { get; set; }
        [Required]
        public int prouductid { get; set; }
    }
}
