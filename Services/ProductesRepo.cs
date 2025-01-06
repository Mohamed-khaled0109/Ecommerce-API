using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class ProductesRepo: IProductesRepo
    {
        private readonly Context context;

        public ProductesRepo(Context _context)
        {
            context = _context;
        }


        public List<Productes> GetAll()
        {
            var list = context.productes.ToList();
            return list;
        }
        public ProductesDto GetById(int id)
        {
            var prodect= context.productes.FirstOrDefault(o => o.Id == id);
            ProductesDto productesDto = new ProductesDto();
            
            productesDto.Name = prodect.Name;
            productesDto.Descrption = prodect.Descrption;
            productesDto.Price= prodect.Price;
            productesDto.stockQuantitu=prodect.stockQuantitu;
            productesDto.Imge=prodect.Imge;
            productesDto.Video=prodect.Video;
            productesDto.idCategores=prodect.idCategores;
            productesDto.idShopingCar=prodect.idShopingCar;

            return productesDto;
        }
        public ProductesDto GetByName(string name)
        {
            var prodect=context.productes.FirstOrDefault(o => o.Name == name);
            ProductesDto productesDto = new ProductesDto();

            productesDto.Name = prodect.Name;
            productesDto.Descrption = prodect.Descrption;
            productesDto.Price = prodect.Price;
            productesDto.stockQuantitu = prodect.stockQuantitu;
            productesDto.Imge = prodect.Imge;
            productesDto.Video = prodect.Video;
            productesDto.idCategores = prodect.idCategores;
            productesDto.idShopingCar = prodect.idShopingCar;

            return productesDto;
        }

        public int Create(ProductesDto productesDto)
        {
            Productes productes =new Productes();

            productes.Name = productesDto.Name;
            productes.Descrption = productesDto.Descrption;
            productes.Price = productesDto.Price;
            productes.stockQuantitu = productesDto.stockQuantitu;
            productes.Imge = productesDto.Imge;
            productes.Video = productesDto.Video;
            productes.idCategores = productesDto.idCategores;
            productes.idShopingCar = productesDto.idShopingCar;

            context.productes.Add(productes);
            return context.SaveChanges();
        }
        public ProductesDto update(int id,ProductesDto NewProducte)
        {
            var OldProducte=context.productes.FirstOrDefault(o=>o.Id== id);

            OldProducte.Name = NewProducte.Name;
            OldProducte.Descrption = NewProducte.Descrption;
            OldProducte.Price = NewProducte.Price;
            OldProducte.stockQuantitu= NewProducte.stockQuantitu;
            OldProducte.Imge= NewProducte.Imge;
            OldProducte.Video= NewProducte.Video;
            OldProducte.idCategores= NewProducte.idCategores;
            OldProducte.idShopingCar= NewProducte.idShopingCar;
            return NewProducte;

        }

        public int Delete(int id)
        {
            var productes = context.productes.FirstOrDefault(o => o.Id == id);
            context.productes.Remove(productes);
            return context.SaveChanges();
        }

    }
}
