namespace PryanikiTask.Application.Dto.Orders
{
    public class CreateOrderDto
    {
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
