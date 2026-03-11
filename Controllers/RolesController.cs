using Microsoft.AspNetCore.Mvc;
using ShipayChallange.Application.Interfaces;

namespace ShipayChallange.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController(IRoleService service) : ControllerBase
{
    private readonly IRoleService _service = service;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string description, CancellationToken cancellationToken)
    {
        var role = await _service.CreateAsync(description, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var roles = await _service.GetAllAsync(cancellationToken);
        return Ok(roles);
    }
    [HttpGet("search/{description}")]
    public async Task<IActionResult> SearchByDescription([FromRoute] string description, CancellationToken cancellationToken)
    {
        var roles = await _service.GetByDescriptionAsync(description, cancellationToken);
        return Ok(roles);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var role = await _service.GetByIdAsync(id, cancellationToken);
        return role is null ? NotFound() : Ok(role);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] string description, CancellationToken cancellationToken)
    {
        await _service.UpdateAsync(id, description, cancellationToken);
        return NoContent();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

}
