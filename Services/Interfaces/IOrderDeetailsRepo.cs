using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IOrderDeetailsRepo
    {
        public List<OrderDeetails> GetAll();
        public OrderDeetailsDto GetById(int id);
        public int Create(OrderDeetailsDto orderDeetails);
        public OrderDeetailsDto update(int id, OrderDeetailsDto newOrderDeetails);
        public int Delete(int id);
    }
}
