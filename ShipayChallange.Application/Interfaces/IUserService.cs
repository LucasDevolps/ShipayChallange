using ShipayChallange.Application.DTOs.Request;
using ShipayChallange.Application.DTOs.Response;

namespace ShipayChallange.Application.Interfaces;

public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserResponse?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(long id, UpdateUserRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);
}
