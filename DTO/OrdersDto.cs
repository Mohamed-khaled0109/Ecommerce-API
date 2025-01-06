using Ecommerce_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_API.DTO
{
    public class OrdersDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public OrderState orderState { get; set; }
        [Required]
        public int idshoppingcart { get; set; }
        [Required]
        public string Userid { get; set; }
        [Required]
        public int shappingId { get; set; }
        [Required]
        public List<string> ordersName {  get; set; }=new List<string>();

    }
}
