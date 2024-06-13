namespace PryanikiTask.Application.Interfaces
{
    public interface IBaseService<T, TCreateDto, TUpdateDto>
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken = default);
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
        Task<T> Create(TCreateDto dto, CancellationToken cancellationToken = default);
        Task<T> Update(int id, TUpdateDto dto, CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancellationToken = default);
    }
}
