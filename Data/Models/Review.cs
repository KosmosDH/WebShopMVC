namespace WebShopMVC.Data.Models
{
    public class Review : Entity
    {
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public required string Author { get; set; }
        public required string Text { get; set; }
    }
}
