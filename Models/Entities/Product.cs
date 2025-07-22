namespace WebShopMVC.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set;}
        public string? Description { get; set; }
        public required int Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
