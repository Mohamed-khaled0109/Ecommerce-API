using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IShoppingCartRepo
    {
        public List<ShoppingCart> GetAll();
        public ShoppingCartDto GetById(int id);
        public int Delete(int id);
        public ShoppingCartDto update(int id, ShoppingCartDto newCart);
        public int Create(ShoppingCartDto shoppingCart);
    }
}
