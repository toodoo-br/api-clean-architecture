using br.com.toodoo.sharedkernel.Interfaces;
using FluentValidation;

namespace br.com.toodoo.sharedkernel;

public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
{
    private readonly IValidator<T> _validator;

    protected BaseService()
    {
    }

    protected BaseService(IValidator<T> validator)
    {
        _validator = validator;
    }

    protected virtual void Validade(T obj)
    {
        _validator.ValidateAndThrow(obj);
    }

    protected virtual async Task ValidadeAsync(T obj)
    {
        await _validator.ValidateAndThrowAsync(obj);
    }
}