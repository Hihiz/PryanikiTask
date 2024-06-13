namespace PryanikiTask.Application.Dto.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public string? OrderDescription { get; set; }
    }
}
