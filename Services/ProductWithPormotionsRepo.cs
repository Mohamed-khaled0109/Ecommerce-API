using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class ProductWithPormotionsRepo: IProductWithPormotionsRepo
    {
        private readonly Context context;

        public ProductWithPormotionsRepo(Context _context)
        {
            context = _context;
        }


        public List<ProductWithPormotions> GetAll()
        {
            var list = context.productWithPormotions.ToList();
            return list;
        }
        public ProductWithPormotionsDto GetById(int id)
        {
            var Prodect= context.productWithPormotions.FirstOrDefault(o => o.Id == id);
            ProductWithPormotionsDto productDto= new ProductWithPormotionsDto();
            
            productDto.ProductId = Prodect.ProductId;
            productDto.Discound= Prodect.Discound;
            productDto.DateStart= Prodect.DateStart;
            productDto.DateEnd= Prodect.DateEnd;
            productDto.UserId= Prodect.UserId;
            
            return productDto;
        }


        public int Create(ProductWithPormotionsDto productWithPormotionsDto)
        {
            ProductWithPormotions productWithPormotions= new ProductWithPormotions();

            productWithPormotions.ProductId = productWithPormotionsDto.ProductId;
            productWithPormotions.Discound = productWithPormotionsDto.Discound;
            productWithPormotions.DateStart = productWithPormotionsDto.DateStart;
            productWithPormotions.DateEnd = productWithPormotionsDto.DateEnd;
            productWithPormotions.UserId = productWithPormotionsDto.UserId;
            
            context.productWithPormotions.Add(productWithPormotions);
            return context.SaveChanges();
        }
        public ProductWithPormotionsDto update(int id, ProductWithPormotionsDto newProductWithPormotions)
        {  
            var OldProductWithPormotions = context.productWithPormotions.FirstOrDefault(o => o.Id == id);
         
            OldProductWithPormotions.DateStart = newProductWithPormotions.DateStart;
            OldProductWithPormotions.DateEnd = newProductWithPormotions.DateEnd;
            OldProductWithPormotions.Discound = newProductWithPormotions.Discound;
            OldProductWithPormotions.UserId=newProductWithPormotions.UserId;
            OldProductWithPormotions.ProductId=newProductWithPormotions.ProductId;

            context.SaveChanges();
            return newProductWithPormotions;
        }

        public int Delete(int id)
        {
            var productWithPormotion = context.productWithPormotions.FirstOrDefault(o => o.Id == id);
            context.productWithPormotions.Remove(productWithPormotion);
            return context.SaveChanges();
        }
    }
}
