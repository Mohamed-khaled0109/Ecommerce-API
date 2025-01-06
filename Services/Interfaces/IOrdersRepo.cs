using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IOrdersRepo
    {
        public List<Orders> GetAll();
        public OrdersDto GetById(int id);
        public int Delete(int id);
        public OrdersDto update(int id, OrdersDto newOrder);
        public int Create(OrdersDto order);

    }
}
