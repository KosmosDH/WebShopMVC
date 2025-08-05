namespace WebShopMVC.Data.Models
{
    public class Review : Entity
    {
        public required int ProductId { get; set; }
        public required string Author { get; set; }
        public required string Text { get; set; }
    }
}
