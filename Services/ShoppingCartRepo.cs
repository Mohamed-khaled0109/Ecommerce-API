using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class ShoppingCartRepo: IShoppingCartRepo
    {
        private readonly Context context;

        public ShoppingCartRepo(Context _context)
        {
            context = _context;
        }

        public List<ShoppingCart> GetAll()
        {
            var list =context.shoppingCarts.ToList();
            return list;
            
        }

        public ShoppingCartDto GetById(int id)
        {
            var shoppingCart= context.shoppingCarts.FirstOrDefault(o => o.Id == id);
            ShoppingCartDto cart = new ShoppingCartDto();
            cart.UserId = shoppingCart.UserId;
            cart.Quntity= shoppingCart.Quntity;
            return cart;
        }
        public int Create(ShoppingCartDto shoppingCartDto)
        {
            ShoppingCart cart = new ShoppingCart();
           
            cart.UserId = shoppingCartDto.UserId;
            cart.Quntity = shoppingCartDto.Quntity;
            
            context.shoppingCarts.Add(cart);
            return context.SaveChanges();
        }

        

        public ShoppingCartDto update(int id, ShoppingCartDto newCart)
        {
            var OldCart = context.shoppingCarts.FirstOrDefault(o => o.Id == id);
            OldCart.UserId = newCart.UserId;
            
            OldCart.Quntity = newCart.Quntity;
            
            return newCart;
        }

        public int Delete(int id)
        {
            var shoppingCart = context.shoppingCarts.FirstOrDefault(o => o.Id == id);
            context.shoppingCarts.Remove(shoppingCart);
            return context.SaveChanges();
        }
    }
}
