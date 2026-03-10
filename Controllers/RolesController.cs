using Microsoft.AspNetCore.Mvc;
using ShipayChallange.Application.Services;

namespace ShipayChallange.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController(RoleService service) : ControllerBase
{
    private readonly RoleService _service = service;

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var role = await _service.GetByIdAsync(id, cancellationToken);
        return role is null ? NotFound() : Ok(role);
    }
}
