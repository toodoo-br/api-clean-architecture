using AutoMapper;
using br.com.toodoo.api.Models;
using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace br.com.toodoo.api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class FormController : ControllerBase
{
    private readonly IFormService _formService;
    private readonly IMapper _mapper;

    public FormController(IFormService formService, IMapper mapper)
    {
        _formService = formService;
        _mapper = mapper;
    }

    [HttpPost("add")]
    [ProducesResponseType(typeof(FormModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddForm([FromBody] FormModel formModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var form = _mapper.Map<Form>(formModel);

            var result = await _formService.Add(form);

            return Created("form", _mapper.Map<FormModel>(result));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{formId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteForm([FromRoute] long formId)
    {
        try
        {
            await _formService.Delete(formId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(List<FormModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetForms()
    {
        var forms = await _formService.ListAsync();

        return Ok(_mapper.Map<List<FormModel>>(forms));
    }

    [HttpPut("update/{formId}")]
    [ProducesResponseType(typeof(FormModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateForm([FromBody] FormModel formModel, [FromRoute] long formId)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var form = _mapper.Map<Form>(formModel);

            await _formService.UpdateAsync(form);

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}