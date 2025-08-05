using WebShopMVC.Data.Models;
using WebShopMVC.Models.DTO;

namespace WebShopMVC.Services
{
    public interface IReviewService
    {
        IList<Review> GetReviewsByProductId(int productId);
        void CreateReview(int productId, ReviewDTO reviewDTO);
    }
}
