using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.DTO
{
    public class ShoppingCartDto
    {
        [Required]
        public int Quntity { get; set; }
        [Required]
        public string UserId { get; set; }
        public List<string> productesName { get; set; }= new List<string>();
    }
}
