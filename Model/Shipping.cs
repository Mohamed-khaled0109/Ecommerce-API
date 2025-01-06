using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Model
{
    public enum ShipingStatus
    {
        InPreparation = 1, // قيد الإعداد
        OnTheWay = 2,      // في الطريق
        Delivered = 3      // تم التوصيل
    }

    public class Shipping
    {
        public int id { get; set; }

        public ShipingStatus shipingStatus { get; set; }

        /*
         تاريخ الشحن
         
         
         */
        [Required]
        public DateTime shippingdate { get; set; }
        /*
         تاريخ المتوقع للتسليم
         */
        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }

        //[ForeignKey("order")]
        //public int Orderid { get; set; }
        public virtual Orders order { get; set; }



    }
}
