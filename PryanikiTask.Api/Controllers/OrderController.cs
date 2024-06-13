using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PryanikiTask.Application.Dto.Orders;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Application.Validations.FluentValidations.Orders;

namespace PryanikiTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBaseService<OrderDto, CreateOrderDto, UpdateOrderDto> _orderService;

        public OrderController(IBaseService<OrderDto, CreateOrderDto, UpdateOrderDto> orderService) => _orderService = orderService;

        [HttpGet]
        public async Task<ActionResult> GetOrders(CancellationToken cancellationToken) => Ok(await _orderService.GetAll(cancellationToken));

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id, CancellationToken cancellationToken) => Ok(await _orderService.GetById(id, cancellationToken));

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderDto dto, CancellationToken cancellationToken)
        {
            CreateOrderValidator validators = new CreateOrderValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _orderService.Create(dto, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateeOrder(int id, UpdateOrderDto dto, CancellationToken cancellationToken)
        {
            UpdateOrderValidator validators = new UpdateOrderValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _orderService.Update(id, dto, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id, CancellationToken cancellationToken)
        {
            await _orderService.Delete(id, cancellationToken);

            return Ok(id);
        }
    }
}
