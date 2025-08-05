namespace WebShopMVC.Data.Models
{
    public class Product : Entity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
