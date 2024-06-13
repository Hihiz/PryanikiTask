namespace PryanikiTask.Application.Dto.Orders
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
