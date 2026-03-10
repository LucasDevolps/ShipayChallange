namespace ShipayChallange.Domain.Entities;

public class Role
{
    public int Id { get; private set; }
    public string Description { get; private set; } = string.Empty;

    public ICollection<User> Users { get; private set; } = new List<User>();

    private Role() { }

    public Role(string description)
    {
        Description = description;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }
}
