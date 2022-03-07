using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.core.Interfaces.Service;
using br.com.toodoo.core.Validations;
using br.com.toodoo.sharedkernel;
using br.com.toodoo.sharedkernel.Interfaces;

namespace br.com.toodoo.service;

public class FieldService : BaseService<Field>, IFieldService
{
    private readonly IFieldRepository _fieldRepository;

    public FieldService(IFieldRepository fieldRepository, INotifier notifier)
        : base(notifier)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<bool> Add(Field field)
    {
        if (!ExecutarValidacao(new FieldValidation(), field)) return false;

        var dataField = _fieldRepository.GetByIdAsync(field.Id);

        if (dataField.Result != null)
        {
            Notificar($"Já existe um Campo com id {field.Id} cadastrado");
            return false;
        }

        await _fieldRepository.AddAsync(field);

        return true;
    }
    public async Task<bool> UpdateAsync(Field field)
    {
        if (!ExecutarValidacao(new FieldValidation(), field)) return false;

        await _fieldRepository.UpdateAsync(field);

        return true;
    }

    public async Task<bool> Delete(long fieldId)
    {
        await _fieldRepository.DeleteAsync(fieldId);

        return true;
    }

    public async Task<Field?> GetByIdAsync(long id)
    {
        return await _fieldRepository.GetByIdAsync(id);
    }

    public async Task<List<Field>> ListAsync()
    {
        return await _fieldRepository.ListAsync();
    }

    public Task<List<Field>> ListFormFieldsAsync(long formId)
    {
        return _fieldRepository.ListFormFieldsAsync(formId);
    }
}
