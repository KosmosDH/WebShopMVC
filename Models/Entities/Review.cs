namespace WebShopMVC.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public required int ProductId { get; set; }
        public required string Author { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
