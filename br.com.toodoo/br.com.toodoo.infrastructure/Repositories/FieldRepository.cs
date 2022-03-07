using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace br.com.toodoo.infrastructure.Repositories;

public class FieldRepository : BaseRepository<Field>, IFieldRepository
{
    public FieldRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
        
    }

    public async Task<List<Field>> ListFormFieldsAsync(long formId)
    {
        return await DatabaseContext.Fields.Where(f => f.FormId == formId).ToListAsync();
    }
}
