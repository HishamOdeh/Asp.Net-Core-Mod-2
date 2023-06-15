namespace Asp.Net_Core_Mod_2.Data
{
    public interface IAsyncContact<T>
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken);

        //Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
