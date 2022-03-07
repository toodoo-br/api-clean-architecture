using br.com.toodoo.sharedkernel.Interfaces;
using br.com.toodoo.sharedkernel.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace br.com.toodoo.sharedkernel;

public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
{
    private readonly INotifier _notifier;

   
    protected BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notificar(error.ErrorMessage);
        }
    }

    protected void Notificar(string mensagem)
    {
        _notifier.Handle(new Notification(mensagem));
    }

    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : T
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }
}