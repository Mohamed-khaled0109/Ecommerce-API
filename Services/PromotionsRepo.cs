using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class PromotionsRepo: IPromotionsRepo
    {
        private readonly Context context;

        public PromotionsRepo(Context _context)
        {
            context = _context;
        }


        public List<Promotions> GetAll()
        {
            var list = context.promotions.ToList();
            return list;
        }
        public PromotionsDto GetById(int id)
        {
            var promotion = context.promotions.FirstOrDefault(o => o.Id == id);
            PromotionsDto promotionsDto = new PromotionsDto();

            promotionsDto.Name = promotion.Name;
            promotionsDto.DateStart = promotion.DateStart;
            promotion.DateEnd = promotion.DateEnd;
            promotionsDto.Discound = promotion.Discound;
            promotionsDto.Productwhith= promotion.Productwhith;
            
            return promotionsDto;
        }
        public PromotionsDto GetByName(string name)
        {
            var promotion = context.promotions.FirstOrDefault(o => o.Name == name);
            PromotionsDto promotionsDto = new PromotionsDto();

            promotionsDto.Name = promotion.Name;
            promotionsDto.DateStart = promotion.DateStart;
            promotion.DateEnd = promotion.DateEnd;
            promotionsDto.Discound = promotion.Discound;
            promotionsDto.Productwhith = promotion.Productwhith;

            return promotionsDto;
        }

        public int Create(PromotionsDto promotionDto)
        {
            var promotion = new Promotions();

            promotion.Name = promotionDto.Name;
            promotion.DateStart = promotionDto.DateStart;
            promotion.DateEnd = promotion.DateEnd;
            promotion.Discound = promotionDto.Discound;
            promotion.Productwhith = promotionDto.Productwhith;

            context.promotions.Add(promotion);
            return context.SaveChanges();
        }
        public PromotionsDto update(int id, PromotionsDto newPromotion)
        {
            var OldPromotion = context.promotions.FirstOrDefault(o => o.Id == id);
            
            OldPromotion.Name= newPromotion.Name;
            OldPromotion.DateStart = newPromotion.DateStart;
            OldPromotion.DateEnd= newPromotion.DateEnd;
            OldPromotion.Discound= newPromotion.Discound;
            OldPromotion.Productwhith= newPromotion.Productwhith;
            context.SaveChanges();
            return newPromotion;
        }

        public int Delete(int id)
        {
            var promotion = context.promotions.FirstOrDefault(o => o.Id == id);
            context.promotions.Remove(promotion);
            return context.SaveChanges();
        }



    }
}
