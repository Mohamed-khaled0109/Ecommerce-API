using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IPromotionsRepo
    {
        public List<Promotions> GetAll();
        public PromotionsDto GetById(int id);
        public PromotionsDto GetByName(string name);
        public int Create(PromotionsDto promotionDto);
        public PromotionsDto update(int id, PromotionsDto newPromotion);
        public int Delete(int id);
    }
}
