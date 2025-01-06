using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IShippingRepo
    {
        public List<Shipping> GetAll();
        public ShippingDto GetById(int id);
        public int Delete(int id);
        public ShippingDto update(int id, ShippingDto NewShipping);
        public int Create(ShippingDto shipping);
    }
}
