using WebShopMVC.Data;
using WebShopMVC.Data.Models;
using WebShopMVC.Models.DTO;

namespace WebShopMVC.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _database;

        public ReviewService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IList<Review> GetReviewsByProductId(int productId)
        {
            return _database.Reviews.Where(r => r.ProductId == productId).ToList();
        }

        public void CreateReview(int productId, ReviewDTO reviewDTO)
        {
            if (string.IsNullOrWhiteSpace(reviewDTO.Author) || string.IsNullOrWhiteSpace(reviewDTO.Text))
                throw new ArgumentException("Review DTO contains null values");

            Review review = new Review()
            {
                ProductId = productId,
                Author = reviewDTO.Author,
                Text = reviewDTO.Text
            };

            _database.Reviews.Add(review);
            _database.SaveChanges();
        }
    }
}
