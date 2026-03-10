using ShipayChallange.Entities;

namespace ShipayChallange.Domain.Entities;

public class UserClaim
{
    public long UserId { get; private set; }
    public long ClaimId { get; private set; }

    public User User { get; private set; } = null!;
    public Claims Claim { get; private set; } = null!;

    private UserClaim() { }

    public UserClaim(long userId, long claimId)
    {
        UserId = userId;
        ClaimId = claimId;
    }
}