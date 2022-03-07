using br.com.toodoo.core.FormAggregate;
using FluentValidation;

namespace br.com.toodoo.core.Validations;

public class FormValidation : AbstractValidator<Form>
{
    public FormValidation()
    {
        RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

    }
}
