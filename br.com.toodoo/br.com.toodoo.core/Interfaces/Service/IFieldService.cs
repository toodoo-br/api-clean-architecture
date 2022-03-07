using br.com.toodoo.core.FieldAggregate;

namespace br.com.toodoo.core.Interfaces.Service;

public interface IFieldService
{
    Task<bool> Add(Field field);
    Task<bool> UpdateAsync(Field field);
    Task<bool> Delete(long fieldId);
    Task<Field?> GetByIdAsync(long id);
    Task<List<Field>> ListAsync();
    Task<List<Field>> ListFormFieldsAsync(long formId);

}
