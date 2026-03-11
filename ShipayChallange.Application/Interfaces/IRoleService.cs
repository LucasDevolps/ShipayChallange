using ShipayChallange.Application.DTOs.Response;

namespace ShipayChallange.Application.Interfaces;

public interface IRoleService
{
    Task<RoleResponse> CreateAsync(string description, CancellationToken cancellationToken = default);
    Task<IEnumerable<RoleResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<RoleResponse?> GetByDescriptionAsync(string description, CancellationToken cancellationToken = default);
    Task<RoleResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, string description, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
