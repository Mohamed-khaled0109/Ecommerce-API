using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_API.Model
{
    public class ApplcationUser : IdentityUser
    {
        [Key]
        public virtual int  Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }


        public virtual ICollection<Orders> orders { get; set; }

        public virtual ICollection<ShoppingCart> shoppingCarts { get; set; }

        public virtual ICollection<ProductReview> reviews { get; set; }

        public virtual ICollection<ProductWithPormotions> productwithpormotions { get; set; }


       

    }
}
