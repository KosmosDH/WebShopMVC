using Microsoft.IdentityModel.Tokens;
using WebShopMVC.Data.Models;
using WebShopMVC.Data.Repositories;
using WebShopMVC.Data.Repositories.Implementations;
using WebShopMVC.Models.DTO;

namespace WebShopMVC.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IList<Review> GetReviewsByProductId(int productId)
        {
            return _reviewRepository.GetByProductId(productId);
        }

        public void CreateReview(int productId, ReviewDTO reviewDTO)
        {
            if (string.IsNullOrWhiteSpace(reviewDTO.Author) || string.IsNullOrWhiteSpace(reviewDTO.Text))
                throw new ArgumentException("Review DTO contains null values");

            Review review = new Review()
            {
                Id = -1,
                ProductId = productId,
                Author = reviewDTO.Author,
                Text = reviewDTO.Text,
                CreatedAt = DateTime.Now
            };

            _reviewRepository.Add(review);
        }
    }
}
