using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface ICategoriesRepo
    {
        public List<Categories> GetAll();
        public CategoriesDto GetById(int id);
        public CategoriesDto GetByName(string name);
        public int Create(CategoriesDto categories);
        public CategoriesDto update(int id, CategoriesDto NewCategories);
        public int Delete(int id);
    }
}
