using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.infrastructure.Database.Context;

namespace br.com.toodoo.infrastructure.Repositories;

public class FieldRepository : BaseRepository<Field>, IFieldRepository
{
    public FieldRepository(DatabaseContext context)
        : base(context)
    {
    }
}