namespace ShipayChallange.Infrastructure.Interfaces;

public interface IPasswordGenerator
{
    string Generate(int length = 10);
}
