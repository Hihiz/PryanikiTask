using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PryanikiTask.Application.Dto.Products;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Application.Validations.FluentValidations.Products;

namespace PryanikiTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBaseService<ProductDto, CreateProductDto, UpdateProductDto> _productService;

        public ProductController(IBaseService<ProductDto, CreateProductDto, UpdateProductDto> productService) => _productService = productService;

        [HttpGet]
        public async Task<ActionResult> GeProducts(CancellationToken cancellationToken) => Ok(await _productService.GetAll(cancellationToken));

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id, CancellationToken cancellationToken) => Ok(await _productService.GetById(id, cancellationToken));

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto dto, CancellationToken cancellationToken)
        {
            CreateProductValidator validators = new CreateProductValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _productService.Create(dto, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateeProduct(int id, UpdateProductDto dto, CancellationToken cancellationToken)
        {
            UpdateProductValidator validators = new UpdateProductValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _productService.Update(id, dto, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            await _productService.Delete(id, cancellationToken);

            return Ok(id);
        }
    }
}
