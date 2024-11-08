using System.Text.Json.Serialization;

namespace AliBazar.Domain.ViewModels;

public class ResponseModel
{
    [JsonPropertyName("is_success")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("error_note")]
    public string? ErrorNote { get; set; }
}
