using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;

namespace Ecommerce_API.Services
{
    public class ProductReviewRepo: IProductReviewRepo
    {
        private readonly Context context;

        public ProductReviewRepo(Context _context)
        {
            context = _context;
        }

        public List<ProductReview> GetAll()
        {
            var list = context.productReviews.ToList();
            return list;
        }
        public ProductReviewDto GetById(int id)
        {
            ProductReview product = context.productReviews.FirstOrDefault(o => o.Id == id);
            ProductReviewDto productReviewDto = new ProductReviewDto();
            
            productReviewDto.ProductId = product.ProductId;
            productReviewDto.Comment = product.Comment;
            productReviewDto.Userid= product.Userid;
            productReviewDto.ReviewDate=product.ReviewDate;
            productReviewDto.Rating=product.Rating;

            return productReviewDto;
        }

        public int Create(ProductReviewDto productReviewDto)
        {
            ProductReview productReview= new ProductReview();

            productReview.ProductId = productReviewDto.ProductId;
            productReview.Comment = productReviewDto.Comment;
            productReview.Userid = productReviewDto.Userid;
            productReview.ReviewDate = productReviewDto.ReviewDate;
            productReview.Rating = productReviewDto.Rating;
            
            context.productReviews.Add(productReview);
            return context.SaveChanges();
        }
        public ProductReviewDto update(int id, ProductReviewDto NewProductReview)
        {
            var OldproductReview = context.productReviews.FirstOrDefault(o => o.Id == id);

            OldproductReview.ReviewDate= NewProductReview.ReviewDate;
            OldproductReview.Comment= NewProductReview.Comment;
            OldproductReview.Rating= NewProductReview.Rating;
            OldproductReview.ProductId=NewProductReview.ProductId;
            OldproductReview.Userid= NewProductReview.Userid;

            return NewProductReview;
        }

        public int Delete(int id)
        {
            var productReview = context.productReviews.FirstOrDefault(o => o.Id == id);
            context.productReviews.Remove(productReview);
            return context.SaveChanges();
        }


    }
}
