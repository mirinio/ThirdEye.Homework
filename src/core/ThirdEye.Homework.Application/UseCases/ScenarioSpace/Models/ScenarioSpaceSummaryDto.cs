using System.Text.Json.Serialization;

namespace ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

public class ScenarioSpaceSummaryDto
{
    [JsonPropertyName("asset_classes")]
    public Dictionary<string, AssetClassItemDto> AssetClasses { get; set; }
    public InflationDto Inflation { get; set; }
}

public class AssetClassItemDto
{
    public ReturnsDto Returns { get; set; }
}

public class ReturnsDto
{
    public float Kurtosis { get; set; }
    public float Mean { get; set; }
    public float Skewnes { get; set; }
    [JsonPropertyName("standard_deviation")]
    public float StandardDeviation { get; set; }
}

public class InflationDto
{
    public float Kurtosis { get; set; }
    public float Mean { get; set; }
    public float Skewnes { get; set; }
    [JsonPropertyName("standard_deviation")]
    public float StandardDeviation { get; set; }
}