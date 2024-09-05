using MediatR;
using Microsoft.AspNetCore.Mvc;
using PinePaste.Api.ModelBinders;
using PinePaste.Application.Pastes.Commands.CreatePaste;
using PinePaste.Application.Pastes.Queries.GetPaste;
using PinePaste.Application.Pastes.Queries.ListPastes;
using PinePaste.Domain.Entities;

namespace PinePaste.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PasteController : ControllerBase
{
    private readonly IMediator _mediator;

    public PasteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paste>>> ListPastes()
    {
        var pastes = await _mediator.Send(new ListPastesQuery());
        return Ok(pastes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Paste>> GetPaste([ModelBinder(typeof(GetPasteQueryModelBinder))] GetPasteQuery query)
    {
        var paste = await _mediator.Send(query);
        return Ok(paste);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaste([FromBody] CreatePasteCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pasteId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetPaste), new { id = pasteId }, null);
    }
}