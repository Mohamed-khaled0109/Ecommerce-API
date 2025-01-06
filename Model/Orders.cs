using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
   
    public enum OrderState
    { 
        Pending = 1, //قيد الانتظار
        Processing = 2,//قيد التنفيذ
        Shipped = 3, //تم الشحن
        Delivered = 4, //تم التوصيل
        Canceled = 5, // تم الالغاء
        Returned = 6 //رجع المصنع تاني
    }
    public class Orders
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        public OrderState orderState { get; set; }

        [ForeignKey("shoppingcart")]
        public int idshoppingcart { get; set; }
        public virtual ShoppingCart shoppingcart { get; set; }

        public virtual ICollection<OrderDeetails> orders { get; set; }

        [ForeignKey("applcationuser")]
        public string Userid { get; set; }
        public virtual ApplcationUser applcationuser { get; set; }

        [ForeignKey("shapping")]
        public int shappingId { get; set; }
        public virtual Shipping shapping { get; set; }


    }
}
