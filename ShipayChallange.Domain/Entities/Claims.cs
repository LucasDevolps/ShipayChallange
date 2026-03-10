using ShipayChallange.Domain.Entities;

namespace ShipayChallange.Entities;

public class Claims
{
    public long Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public bool Active { get; private set; }

    public ICollection<UserClaim> UserClaims { get; private set; } = new List<UserClaim>();

    private Claims() { }

    public Claims(string description, bool active = true)
    {
        Description = description;
        Active = active;
    }
}
