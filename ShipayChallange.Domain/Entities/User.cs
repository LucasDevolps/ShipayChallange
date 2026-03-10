namespace ShipayChallange.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public int RoleId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Role Role { get; private set; } = null!;
    public ICollection<UserClaim> UserClaims { get; private set; } = new List<UserClaim>();

    private User() { }

    public User(string name, string email, string password, int roleId)
    {
        Name = name;
        Email = email;
        Password = password;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow.Date;
    }

    public void Update(string name, string email, int roleId)
    {
        Name = name;
        Email = email;
        RoleId = roleId;
        UpdatedAt = DateTime.UtcNow.Date;
    }

    public void ChangePassword(string password)
    {
        Password = password;
        UpdatedAt = DateTime.UtcNow.Date;
    }
}
