using Microsoft.EntityFrameworkCore;
using ShipayChallange.Application.DTOs.Response;
using ShipayChallange.Application.Interfaces;
using ShipayChallange.Infrastructure.Persistence;

namespace ShipayChallange.Application.Services;

public sealed class RoleService(AppDbContext context) : IRoleService
{
    private readonly AppDbContext _context = context;

    public async Task<RoleResponse> CreateAsync(string description, CancellationToken cancellationToken = default)
    {
        var role = new Domain.Entities.Role(description);
        _context.Roles.Add(role);
        await _context.SaveChangesAsync(cancellationToken);
        return new RoleResponse(role.Id, role.Description);
    }
    public async Task<IEnumerable<RoleResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Roles
            .AsNoTracking()
            .Select(x => new RoleResponse(x.Id, x.Description))
            .ToListAsync(cancellationToken);
    }
    public async Task<RoleResponse?> GetByDescriptionAsync(string description, CancellationToken cancellationToken = default)
    {
        return await _context.Roles
            .AsNoTracking()
            .Where(x => x.Description == description)
            .Select(x => new RoleResponse(x.Id, x.Description))
            .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<RoleResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Roles
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new RoleResponse(x.Id, x.Description))
            .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task UpdateAsync(int id, string description, CancellationToken cancellationToken = default)
    {
        var role = await _context.Roles.FindAsync(id, cancellationToken);
        if (role is not null)
        {
            role.UpdateDescription(description);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var role = await _context.Roles.FindAsync(id, cancellationToken);
        if (role is not null)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
