using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class CategoriesRepo: ICategoriesRepo
    {
        private readonly Context context;

        public CategoriesRepo(Context _context)
        {
            context = _context;
        }


        public List<Categories> GetAll()
        {
            var list = context.categories.ToList();
            return list;
        }
        public CategoriesDto GetById(int id)
        {
            var category= context.categories.FirstOrDefault(o => o.Id == id);
            CategoriesDto categoriesDto = new CategoriesDto();
            
            categoriesDto.Name = category.Name;
            foreach(var item in category.prod)
            {
                categoriesDto.ProductesName.Add(item.Name.ToString());
            }
            return categoriesDto;
        }
        public CategoriesDto GetByName(string name)
        {
            var category = context.categories.FirstOrDefault(o => o.Name == name);
            CategoriesDto categoriesDto = new CategoriesDto();

            categoriesDto.Name = category.Name;
            foreach (var item in category.prod)
            {
                categoriesDto.ProductesName.Add(item.Name.ToString());
            }
            return categoriesDto;
        }

        public int Create(CategoriesDto categoriesDto)
        {
            Categories categories= new Categories();
            
            categories.Name = categoriesDto.Name;
            
            context.categories.Add(categories);
            return context.SaveChanges();
        }
        public CategoriesDto update(int id, CategoriesDto NewCategories)
        {
            var OldCategories = context.categories.FirstOrDefault(o => o.Id == id);
            OldCategories.Name= NewCategories.Name;
            return NewCategories;
        }

        public int Delete(int id)
        {
            var categories = context.categories.FirstOrDefault(o => o.Id == id);
            context.categories.Remove(categories);
            return context.SaveChanges();
        }

    }
}
