namespace AliBazar.Application.Services.PasswrodHashing;
public interface IPasswordHasher
{
    public string Hash(string password, string salt);
    public bool Verify(string password, string hashedPassword, string salt);
}

