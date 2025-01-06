using Ecommerce_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_API.DTO
{
    public class ShippingDto
    {
        [Required]
        public ShipingStatus shipingStatus { get; set; }
        [Required]
        public DateTime shippingdate { get; set; }
        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }


    }
}
