using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.infrastructure.Database.Context;
using br.com.toodoo.sharedkernel;
using Microsoft.EntityFrameworkCore;

namespace br.com.toodoo.infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected BaseRepository(DatabaseContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    protected DatabaseContext DatabaseContext { get; }

    public virtual async Task<T> AddAsync(T obj)
    {
        DatabaseContext.Set<T>().Add(obj);
        await DatabaseContext.SaveChangesAsync();
        return obj;
    }

    public virtual async Task DeleteAsync(long id)
    {
        var obj = (T)Activator.CreateInstance(typeof(T));
        obj.Id = id;
        obj.Modified = DateTime.UtcNow;

        DatabaseContext.Set<T>().Attach(obj);
        DatabaseContext.Entry(obj).Property(x => x.Modified).IsModified = true;

        await DatabaseContext.SaveChangesAsync();
    }

    public virtual async Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull
    {
        return await DatabaseContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<List<T>> ListAsync()
    {
        return await DatabaseContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> UpdateAsync(T obj)
    {
        DatabaseContext.Entry(obj).State = EntityState.Modified;
        await DatabaseContext.SaveChangesAsync();
        return obj;
    }
}