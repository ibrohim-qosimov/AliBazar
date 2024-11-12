using System.Security.Cryptography;
using System.Text;

namespace AliBazar.Application.Services.PasswrodHashing;

public class PasswordHasher : IPasswordHasher
{
    private const int KeySize = 32;
    private const int IterationsCount = 1000;

    public string Hash(string password, string salt)
    {
        using (var algorithm = new Rfc2898DeriveBytes(
                 password: password,
                 salt: Encoding.UTF8.GetBytes(salt),
                 iterations: IterationsCount,
                 hashAlgorithm: HashAlgorithmName.SHA256))
        {
            var bytes = algorithm.GetBytes(KeySize);
            return Convert.ToBase64String(bytes);
        }

    }

    public bool Verify(string password, string hashedPassword, string salt)
    {
        return Hash(password, salt).Equals(hashedPassword);
    }
}
