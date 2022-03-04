using AutoMapper;
using br.com.toodoo.api.Models;
using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace br.com.toodoo.api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class FieldController : ControllerBase
{
    private readonly IFieldService _fieldService;
    private readonly IMapper _mapper;

    public FieldController(IFieldService fieldService, IMapper mapper)
    {
        _fieldService = fieldService;
        _mapper = mapper;
    }

    [HttpPost("add")]
    [ProducesResponseType(typeof(FieldModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddField([FromBody] FieldModel fieldModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var field = _mapper.Map<Field>(fieldModel);

            var result = await _fieldService.Add(field);

            return Created("field", _mapper.Map<FieldModel>(result));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{fieldId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteField([FromRoute] long fieldId)
    {
        try
        {
            await _fieldService.Delete(fieldId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(List<FieldModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFields()
    {
        var fields = await _fieldService.ListAsync();

        return Ok(_mapper.Map<List<FieldModel>>(fields));
    }

    [HttpPut("update/{fieldId}")]
    [ProducesResponseType(typeof(FieldModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateField([FromBody] FieldModel fieldModel, [FromRoute] long fieldId)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var field = _mapper.Map<Field>(fieldModel);

            await _fieldService.UpdateAsync(field);

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}