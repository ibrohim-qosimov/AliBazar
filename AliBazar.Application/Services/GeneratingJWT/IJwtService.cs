using AliBazar.Domain.Entities;

namespace AliBazar.Application.Services.GeneratingJWT;
public interface IJwtService
{
    public string GenerateToken(User user);
}

