namespace ShipayChallange.Application.DTOs.Request;

public record CreateUserRequest(
    string Name,
    string Email,
    string? Password,
    int RoleId);

