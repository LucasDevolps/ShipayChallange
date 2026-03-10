using Microsoft.EntityFrameworkCore;
using ShipayChallange.Application.DTOs.Request;
using ShipayChallange.Application.DTOs.Response;
using ShipayChallange.Domain.Entities;
using ShipayChallange.Infrastructure.Interfaces;
using ShipayChallange.Infrastructure.Persistence;

namespace ShipayChallange.Application.Services;

public sealed class UserService(AppDbContext context, IPasswordGenerator passwordGenerator)
{
    private readonly AppDbContext _context = context;
    private readonly IPasswordGenerator _passwordGenerator = passwordGenerator;

    public async Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var roleExists = await _context.Roles.AnyAsync(x => x.Id == request.RoleId, cancellationToken);
        if (!roleExists)
            throw new Exception("Role not found.");

        var emailExists = await _context.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (emailExists)
            throw new Exception("E-mail already exists.");

        var password = string.IsNullOrWhiteSpace(request.Password)
            ? _passwordGenerator.Generate()
            : request.Password;

        var user = new User(request.Name, request.Email, password, request.RoleId);

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        var role = await _context.Roles
            .Where(x => x.Id == user.RoleId)
            .Select(x => x.Description)
            .FirstAsync(cancellationToken);

        return new UserResponse(
            user.Id,
            user.Name,
            user.Email,
            user.RoleId,
            role,
            user.CreatedAt,
            DateTime.Now            
        );
    }

    public async Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .Select(x => new UserResponse(
                x.Id,
                x.Name,
                x.Email,
                x.RoleId,
                x.Role.Description,
                x.CreatedAt,
                x.UpdatedAt ?? DateTime.Now
            ))
            .ToListAsync(cancellationToken);
    }

    public async Task<UserResponse?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .Where(x => x.Id == id)
            .Select(x => new UserResponse(
                x.Id,
                x.Name,
                x.Email,
                x.RoleId,
                x.Role.Description,
                x.CreatedAt,
                x.UpdatedAt ?? DateTime.Now
            ))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(long id, UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (user is null) return false;

        var roleExists = await _context.Roles.AnyAsync(x => x.Id == request.RoleId, cancellationToken);
        if (!roleExists)
            throw new Exception("Role not found.");

        var emailInUse = await _context.Users.AnyAsync(x => x.Email == request.Email && x.Id != id, cancellationToken);
        if (emailInUse)
            throw new Exception("E-mail already exists.");

        user.Update(request.Name, request.Email, request.RoleId);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (user is null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
