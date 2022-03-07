using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace br.com.toodoo.infrastructure.Repositories;

public class FormRepository : BaseRepository<Form>, IFormRepository
{
    public FormRepository(DatabaseContext context)
        : base(context)
    {
    }

    public async Task<Form> GetFormField(long id)
    {
        var form = await DatabaseContext.Forms.AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);
       
        //TODO Alterar para Include quando estiver persistido no banco de dados
        form.Fields = await DatabaseContext.Fields.Where(f => f.FormId == id).ToListAsync();

        return form;
    }
}