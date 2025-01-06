using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IProductesRepo
    {
        public List<Productes> GetAll();
        public ProductesDto GetById(int id);
        public ProductesDto GetByName(string name);
        public int Create(ProductesDto productes);
        public ProductesDto update(int id, ProductesDto NewProducte);
        public int Delete(int id);
    }
}
