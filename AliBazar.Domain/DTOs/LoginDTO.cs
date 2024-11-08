using System.Text.Json.Serialization;

namespace AliBazar.Domain.DTOs;

public class LoginDTO
{
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
}
