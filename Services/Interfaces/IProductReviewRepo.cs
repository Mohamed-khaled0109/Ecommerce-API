using Ecommerce_API.DTO;
using Ecommerce_API.Model;

namespace Ecommerce_API.Services.Interfaces
{
    public interface IProductReviewRepo
    {
        public List<ProductReview> GetAll();
        public ProductReviewDto GetById(int id);
        public int Create(ProductReviewDto productReview);
        public ProductReviewDto update(int id, ProductReviewDto NewProductReview);
        public int Delete(int id);
    }
}
