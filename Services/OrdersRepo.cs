using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;
using System.Security.Cryptography;

namespace Ecommerce_API.Services
{
    public class OrdersRepo:IOrdersRepo
    {
        private readonly Context context;

        public OrdersRepo(Context _context) 
        {
            context = _context;
        }


        public List<Orders> GetAll()
        {
            var list=context.Order.ToList();
            return list;
        }
        public OrdersDto GetById(int id)
        {

            var order=context.Order.FirstOrDefault(o => o.Id == id);

            OrdersDto orderdto= new OrdersDto();

            orderdto.Date = order.Date;
            orderdto.orderState=order.orderState;
            orderdto.shappingId=order.shappingId;
            orderdto.Userid=order.Userid;
            
            foreach(var item in order.orders)
            {
                orderdto.ordersName.Add(item.ToString());


            }
            return orderdto;

        }



        public int Create(OrdersDto orderdto)
        {
            Orders orders = new Orders();

            orders.Date = orderdto.Date;
            orders.orderState = orderdto.orderState;
            orders.shappingId = orderdto.shappingId;
            orders.Userid = orderdto.Userid;


            context.Order.Add(orders);
            return context.SaveChanges();
        }
        public OrdersDto update(int id, OrdersDto newOrder)
        {
            var OldOrders = context.Order.FirstOrDefault(o => o.Id == id);

            OldOrders.orderState = newOrder.orderState;
            OldOrders.Date = newOrder.Date;
            OldOrders.TotalAmount = newOrder.TotalAmount;
            OldOrders.idshoppingcart = newOrder.idshoppingcart;
            OldOrders.shappingId=newOrder.shappingId;
            return newOrder;
        }

        public int Delete(int id)
        {
            var order = context.Order.FirstOrDefault(o=>o.Id==id);
            context.Order.Remove(order);
            return context.SaveChanges();   
        }

       

    }
}
