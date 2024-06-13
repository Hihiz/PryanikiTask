using AutoMapper;
using PryanikiTask.Application.Common.Exceptions;
using PryanikiTask.Application.Dto.Orders;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Application.Services
{
    public class OrderService : IBaseService<OrderDto, CreateOrderDto, UpdateOrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Order> _repository;

        public OrderService(IMapper mapper, IBaseRepository<Order> repository) => (_mapper, _repository) = (mapper, repository);

        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                List<Order> orders = await _repository.GetAll(cancellationToken);
                List<OrderDto> ordersDto = _mapper.Map<List<OrderDto>>(orders);

                return ordersDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<OrderDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                Order order = await _repository.GetById(id, cancellationToken);

                if (order == null)
                {
                    throw new NotFoundException(nameof(Order), id);
                }

                OrderDto orderDto = _mapper.Map<OrderDto>(order);

                return orderDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new NotFoundException(nameof(Order), id);
            }
        }

        public async Task<OrderDto> Create(CreateOrderDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null)
                {
                    throw new NotFoundException(nameof(Order), dto);
                }

                Order order = _mapper.Map<Order>(dto);

                await _repository.Create(order, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                OrderDto orderDto = _mapper.Map<OrderDto>(order);

                return orderDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<OrderDto> Update(int id, UpdateOrderDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id != dto.Id || dto == null)
                {
                    throw new NotFoundException(nameof(Order), id);
                }

                Order order = _mapper.Map<Order>(dto);

                await _repository.Update(order, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                OrderDto orderDto = _mapper.Map<OrderDto>(order);

                return orderDto;
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
                Order order = await _repository.GetById(id, cancellationToken);

                if (order == null)
                {
                    throw new NotFoundException(nameof(Order), id);
                }

                await _repository.Delete(order);
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
