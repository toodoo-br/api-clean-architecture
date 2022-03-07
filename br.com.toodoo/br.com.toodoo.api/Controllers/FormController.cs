using AutoMapper;
using br.com.toodoo.api.Models;
using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.core.Interfaces.Service;
using br.com.toodoo.sharedkernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace br.com.toodoo.api.Controllers;

[Route("[controller]")]
[Produces("application/json")]
public class FormController : MainController
{
    private readonly IFormService _formService;
    private readonly IMapper _mapper;

    public FormController(IFormService formService,
                          IMapper mapper,
                          INotifier notifier) : base(notifier)
    {
        _formService = formService;
        _mapper = mapper;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddForm([FromBody] FormModel formModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var form = _mapper.Map<Form>(formModel);

        await _formService.Add(form);

        return CustomResponse(formModel);
    }

    [HttpDelete("{formId:long}")]
    public async Task<IActionResult> DeleteForm([FromRoute] long formId)
    {
        var formModel = await GetForm(formId);

        if (formModel == null) return NotFound();

        await _formService.Delete(formId);

        return CustomResponse(formModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetForms()
    {
        var forms = await _formService.ListAsync();

        return CustomResponse(_mapper.Map<List<FormModel>>(forms));
    }

    [HttpGet("{formId:long}")]
    [ProducesResponseType(typeof(List<FormModel>), StatusCodes.Status200OK)]
    public async Task<FormModel> GetFormFields(long formId)
    {
        return _mapper.Map<FormModel>(await _formService.GetFormFields(formId));
    }

    [HttpPut("update/{formId:long}")]
    public async Task<IActionResult> UpdateForm([FromBody] FormModel formModel, [FromRoute] long formId)
    {
        if (formId != formModel.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(formModel);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var form = _mapper.Map<Form>(formModel);

        await _formService.UpdateAsync(form);

        return CustomResponse(formModel);
    }

    private async Task<FormModel> GetForm(long formId)
    {
        return _mapper.Map<FormModel>(await _formService.GetByIdAsync(formId));
    }
}