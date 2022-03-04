using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.infrastructure.Database.Context;

namespace br.com.toodoo.infrastructure.Repositories;

public class FormRepository : BaseRepository<Form>, IFormRepository
{
    public FormRepository(DatabaseContext context)
        : base(context)
    {
    }
}