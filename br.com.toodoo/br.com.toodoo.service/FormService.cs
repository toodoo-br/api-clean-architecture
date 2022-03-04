using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.core.Interfaces.Service;
using br.com.toodoo.sharedkernel;

namespace br.com.toodoo.service;

public class FormService : BaseService<Form>, IFormService
{
    private readonly IFormRepository _formRepository;

    public FormService(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public async Task<Form> Add(Form form)
    {
        return await _formRepository.AddAsync(form);
    }

    public async Task Delete(long formId)
    {
        await _formRepository.DeleteAsync(formId);
    }

    public async Task<Form?> GetByIdAsync(long id)
    {
        return await _formRepository.GetByIdAsync(id);
    }

    public async Task<List<Form>> ListAsync()
    {
        return await _formRepository.ListAsync();
    }

    public async Task<Form> UpdateAsync(Form form)
    {
        return await _formRepository.UpdateAsync(form);
    }
}