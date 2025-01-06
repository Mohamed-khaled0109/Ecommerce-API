using System.ComponentModel.DataAnnotations;

namespace Ecommerce_API.DTO
{
    public class CategoriesDto
    {
        [Required]
        public string Name {  get; set; }
        public List<string> ProductesName {  get; set; }=new List<string>();
    }
}
