using br.com.toodoo.sharedkernel;

namespace br.com.toodoo.core.Interfaces.Infrastructure;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T obj);
    Task DeleteAsync(long id);
    Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull;
    Task<List<T>> ListAsync();
    Task<T> UpdateAsync(T obj);
}