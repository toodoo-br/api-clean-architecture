using br.com.toodoo.core.FieldAggregate;

namespace br.com.toodoo.core.Interfaces.Infrastructure;

public interface IFieldRepository : IBaseRepository<Field>
{
    Task<List<Field>> ListFormFieldsAsync(long formId);

}
