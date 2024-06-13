namespace PryanikiTask.Application.Dto.Products
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
    }
}
