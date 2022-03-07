using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.core.Interfaces.Service;
using br.com.toodoo.core.Validations;
using br.com.toodoo.sharedkernel;
using br.com.toodoo.sharedkernel.Interfaces;

namespace br.com.toodoo.service;

public class FormService : BaseService<Form>, IFormService
{
    private readonly IFormRepository _formRepository;

    public FormService(IFormRepository formRepository, INotifier notifier)
        : base(notifier)
    {
        _formRepository = formRepository;
    }

    public async Task<bool> Add(Form form)
    {
        if (!ExecutarValidacao(new FormValidation(), form)) return false;

        var dataForm = _formRepository.GetByIdAsync(form.Id);

        if (dataForm.Result != null)
        {
            Notificar($"Já existe um formulário com id {form.Id} cadastrado");
            return false;
        }

        await _formRepository.AddAsync(form);

        return true;
    }

    public async Task<bool> UpdateAsync(Form form)
    {
        if (!ExecutarValidacao(new FormValidation(), form)) return false;

        await _formRepository.UpdateAsync(form);

        return true;
    }

    public async Task<bool> Delete(long formId)
    {
        var hasFildsForm = await _formRepository.GetFormField(formId);

        if (hasFildsForm == null)
        {
            Notificar("Formulário não localizado");
            return false;
        }

        if (hasFildsForm.Fields?.Count() > 0)
        {
            Notificar("O Formulário possui campos cadastrados");
            return false;
        }

        await _formRepository.DeleteAsync(formId);

        return true;
    }

    public async Task<Form?> GetByIdAsync(long id)
    {
        return await _formRepository.GetByIdAsync(id);
    }

    public async Task<List<Form>> ListAsync()
    {
        return await _formRepository.ListAsync();
    }

    public async Task<Form> GetFormFields(long formId)
    {
        return await _formRepository.GetFormField(formId);
    }
}