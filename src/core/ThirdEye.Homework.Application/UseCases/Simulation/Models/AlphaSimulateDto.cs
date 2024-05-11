using System.Text.Json.Serialization;

namespace ThirdEye.Homework.Application.UseCases.Simulation.Models;

public class AlphaSimulateDto
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; }
    
    public WealthDto Wealth { get; set; }
}

public class WealthDto
{
    public Dictionary<string, float[]> Total { get; set; }
    public Dictionary<string, float[]> Loans { get; set; }
}
