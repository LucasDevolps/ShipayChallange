using Microsoft.EntityFrameworkCore;
using ShipayChallange.Application.DTOs.Response;
using ShipayChallange.Infrastructure.Persistence;

namespace ShipayChallange.Application.Services;

public sealed class RoleService
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context) => _context = context;

    public async Task<RoleResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Roles
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new RoleResponse(x.Id, x.Description))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
