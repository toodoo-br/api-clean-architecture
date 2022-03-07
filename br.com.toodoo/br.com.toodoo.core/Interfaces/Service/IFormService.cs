using br.com.toodoo.core.FormAggregate;

namespace br.com.toodoo.core.Interfaces.Service;

public interface IFormService
{
    Task<bool> Add(Form form);
    Task<bool> UpdateAsync(Form form);
    Task<bool> Delete(long formId);
    Task<Form?> GetByIdAsync(long id);
    Task<List<Form>> ListAsync();
    Task<Form> GetFormFields(long formId);
}