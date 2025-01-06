using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IProductWithPormotionsRepo
    {
        public List<ProductWithPormotions> GetAll();
        public ProductWithPormotionsDto GetById(int id);
        public int Create(ProductWithPormotionsDto productWithPormotions);
        public ProductWithPormotionsDto update(int id, ProductWithPormotionsDto newProductWithPormotions);
        public int Delete(int id);
    }
}
