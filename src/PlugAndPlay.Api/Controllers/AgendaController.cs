using Microsoft.AspNetCore.Mvc;
using PlugAndPlay.Api.DTOs;
using PlugAndPlay.Api.Managers;
using PlugAndPlay.Api.Models;

namespace PlugAndPlay.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendaController : BaseController
{
    private readonly AgendaManager _manager;

    public AgendaController(AgendaManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ManagerResult<List<AgendaDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _manager.GetAllAgendasAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ManagerResult<AgendaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _manager.GetAgendaByIdAsync(id);
        if (result.Data == null) return NotFound(result);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ManagerResult<AgendaDto>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] AgendaDto dto)
    {
        var result = await _manager.CreateAgendaAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = result.Data!.Id }, result);
    }
}
