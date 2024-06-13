namespace PryanikiTask.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
