using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class OrderDeetailsRepo: IOrderDeetailsRepo
    {
        private readonly Context context;

        public OrderDeetailsRepo(Context _context)
        {
            context = _context;
        }


        public List<OrderDeetails> GetAll()
        {
            var list = context.orderdeetails.ToList();
            return list;
        }
        public OrderDeetailsDto GetById(int id)
        {
            var order= context.orderdeetails.FirstOrDefault(o => o.Id == id);
            OrderDeetailsDto orderDeetailsDto = new OrderDeetailsDto();
            
            orderDeetailsDto.Quantity = order.Quantity;
            orderDeetailsDto.OrderId = order.OrderId;
            orderDeetailsDto.prouductid= order.prouductid;
            
            return orderDeetailsDto;
        }

        public int Create(OrderDeetailsDto orderDeetailsDto)
        {
            OrderDeetails orderDeetails = new OrderDeetails();

            orderDeetails.Quantity = orderDeetailsDto.Quantity;
            orderDeetails.OrderId = orderDeetailsDto.OrderId;
            orderDeetails.prouductid = orderDeetailsDto.prouductid;
            
            context.orderdeetails.Add(orderDeetails);
            return context.SaveChanges();
        }
        public OrderDeetailsDto update(int id, OrderDeetailsDto newOrderDeetails)
        {
            var OldOrderDeetails = context.orderdeetails.FirstOrDefault(o => o.Id == id);

            OldOrderDeetails.Quantity=newOrderDeetails.Quantity;
            OldOrderDeetails.OrderId=newOrderDeetails.OrderId;
            OldOrderDeetails.prouductid=newOrderDeetails.prouductid;

            return newOrderDeetails;
        }

        public int Delete(int id)
        {
            var orderDeetails = context.orderdeetails.FirstOrDefault(o => o.Id == id);
            context.orderdeetails.Remove(orderDeetails);
            return context.SaveChanges();
        }
    }
}
