namespace AliBazar.Application.Services.PasswrodHashing;
internal interface IPasswordHasher
{
    public string Hash(string password);
    public bool Verify(string password, string hashedPassword);
}

