using AutoMapper;
using br.com.toodoo.api.Models;
using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.Interfaces.Service;
using br.com.toodoo.sharedkernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace br.com.toodoo.api.Controllers;

[Route("[controller]")]
[Produces("application/json")]
public class FieldController : MainController
{
    private readonly IFieldService _fieldService;
    private readonly IMapper _mapper;

    public FieldController(IFieldService fieldService,
                           IMapper mapper,
                           INotifier notifier) : base(notifier)
    {
        _fieldService = fieldService;
        _mapper = mapper;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddField([FromBody] FieldModel fieldModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var form = _mapper.Map<Field>(fieldModel);

        await _fieldService.Add(form);

        return CustomResponse(fieldModel);
    }

    [HttpPut("update/{fieldId:long}")]
    public async Task<IActionResult> UpdateField([FromBody] FieldModel fieldModel, [FromRoute] long fieldId)
    {
        if (fieldId != fieldModel.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(fieldModel);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var form = _mapper.Map<Field>(fieldModel);

        await _fieldService.UpdateAsync(form);

        return CustomResponse(fieldModel);
    }

    [HttpGet("{fieldId:long}")]
    [ProducesResponseType(typeof(List<FieldModel>), StatusCodes.Status200OK)]
    public async Task<FieldModel> GetFieldId(long fieldId)
    {
        return await GetField(fieldId);
    }

    [HttpGet("form/{formId:long}/fields")]
    public async Task<IActionResult> GetFormFields(long formId)
    {
        var fields = await _fieldService.ListFormFieldsAsync(formId);

        return CustomResponse(_mapper.Map<List<FieldModel>>(fields));
    }

    [HttpDelete("{fieldId:long}")]
    public async Task<IActionResult> DeleteField([FromRoute] long fieldId)
    {
        var fieldModel = await GetField(fieldId);

        if (fieldModel != null) return NotFound();

        await _fieldService.Delete(fieldId);

        return CustomResponse(fieldModel);
    }

    private async Task<FieldModel> GetField(long fieldId)
    {
        return _mapper.Map<FieldModel>(await _fieldService.GetByIdAsync(fieldId));
    }
}
