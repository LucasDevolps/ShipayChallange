using ShipayChallange.Infrastructure.Interfaces;
using System.Security.Cryptography;

namespace ShipayChallange.Infrastructure.Security;

public sealed class PasswordGenerator : IPasswordGenerator
{
    private const string _validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%";

    public string Generate(int length = 10)
    {
        var bytes = new byte[length];
        RandomNumberGenerator.Fill(bytes);

        var chars = bytes
            .Select(b => _validChars[b % _validChars.Length])
            .ToArray();

        return new string(chars);
    }
}
