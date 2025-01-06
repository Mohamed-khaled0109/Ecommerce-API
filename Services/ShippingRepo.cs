using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class ShippingRepo:IShippingRepo
    {
        private readonly Context context;

        public ShippingRepo(Context _context)
        {
            context = _context;
        }

        public List<Shipping> GetAll()
        {
            return context.shipping.ToList();
            
        }

        public ShippingDto GetById(int id)
        {
            var shipping= context.shipping.FirstOrDefault(o => o.id == id);
            var shippingDto = new ShippingDto();
            
            shippingDto.shippingdate = shipping.shippingdate;
            shippingDto.shipingStatus = shipping.shipingStatus;
            shippingDto.EstimatedDeliveryDate = shipping.EstimatedDeliveryDate;
            return shippingDto;
            
        }

        public int Delete(int id)
        {
            var shipping = context.shipping.FirstOrDefault(o => o.id == id);
            context.shipping.Remove(shipping);
            return context.SaveChanges();
        }

        public ShippingDto update(int id, ShippingDto NewShipping)
        {
            var OldShipping = context.shipping.FirstOrDefault(o => o.id == id);
            OldShipping.shippingdate = NewShipping.shippingdate;
            OldShipping.shipingStatus = NewShipping.shipingStatus;
            OldShipping.EstimatedDeliveryDate = NewShipping.EstimatedDeliveryDate;
            context.SaveChanges();
            return NewShipping;
        }

        public int Create(ShippingDto shippingDto)
        {
            var shipping= new Shipping();
            shipping.shippingdate = shippingDto.shippingdate;
            shipping.shipingStatus = shippingDto.shipingStatus;
            shipping.EstimatedDeliveryDate = shippingDto.EstimatedDeliveryDate;

            context.shipping.Add(shipping);
            return context.SaveChanges();
        }

    }
}
