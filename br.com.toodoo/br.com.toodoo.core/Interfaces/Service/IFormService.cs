using br.com.toodoo.core.FormAggregate;

namespace br.com.toodoo.core.Interfaces.Service;

public interface IFormService
{
    Task<Form> Add(Form form);
    Task Delete(long formId);
    Task<Form?> GetByIdAsync(long id);
    Task<List<Form>> ListAsync();
    Task<Form> UpdateAsync(Form form);
}