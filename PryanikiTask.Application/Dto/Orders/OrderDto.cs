﻿using PryanikiTask.Application.Dto.Products;

namespace PryanikiTask.Application.Dto.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ProductCollectionDto> Products { get; } = new List<ProductCollectionDto>();
    }
}
