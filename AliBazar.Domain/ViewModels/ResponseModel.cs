using System.Text.Json.Serialization;

namespace AliBazar.Domain.ViewModels;

public class ResponseModel
{
    [JsonPropertyName("is_success")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }
}
