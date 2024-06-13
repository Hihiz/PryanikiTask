namespace PryanikiTask.Application.Dto.Products
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
    }
}
