namespace ShipayChallange.Application.DTOs.Request;

public record UpdateUserRequest(
    string Name,
    string Email,
    string Password,
    int RoleId
);
