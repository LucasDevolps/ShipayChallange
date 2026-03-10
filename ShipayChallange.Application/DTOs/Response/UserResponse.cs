namespace ShipayChallange.Application.DTOs.Response;

public record UserResponse(
    long Id,
    string Name,
    string Email,
    int RoleId,
    string RoleDescription,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
