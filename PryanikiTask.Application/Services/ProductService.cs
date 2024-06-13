using AutoMapper;
using PryanikiTask.Application.Common.Exceptions;
using PryanikiTask.Application.Dto.Products;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Application.Services
{
    public class ProductService : IBaseService<ProductDto, CreateProductDto, UpdateProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Product> _repository;

        public ProductService(IMapper mapper, IBaseRepository<Product> repository) => (_mapper, _repository) = (mapper, repository);

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                List<Product> products = await _repository.GetAll(cancellationToken);
                List<ProductDto> productsDto = _mapper.Map<List<ProductDto>>(products);

                return productsDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ProductDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                Product product = await _repository.GetById(id, cancellationToken);


                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), id);
                }

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return productDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new NotFoundException(nameof(ProductDto), id);
            }
        }

        public async Task<ProductDto> Create(CreateProductDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null)
                {
                    throw new NotFoundException(nameof(Product), dto);
                }

                Product product = _mapper.Map<Product>(dto);

                await _repository.Create(product, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return productDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ProductDto> Update(int id, UpdateProductDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id != dto.Id || dto == null)
                {
                    throw new NotFoundException(nameof(Product), id);
                }

                Product product = _mapper.Map<Product>(dto);

                await _repository.Update(product, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return productDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                Product product = await _repository.GetById(id, cancellationToken);

                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), id);
                }

                await _repository.Delete(product);
                await _repository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
