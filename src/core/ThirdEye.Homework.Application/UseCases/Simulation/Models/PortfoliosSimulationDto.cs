using System.Text.Json.Serialization;

namespace ThirdEye.Homework.Application.UseCases.Simulation.Models;

public class PortfoliosSimulationDto
{
    public IList<PortfolioDto> Portfolios { get; set; }
    [JsonPropertyName("goal_percentiles")]
    public int[] GoalPercentiles { get; set; }
    public int Scenarios { get; set; }
    [JsonPropertyName("wealth_returns")]
    public int[] WealthReturns { get; set; }
    [JsonPropertyName("total_quarters")]
    public int TotalQuarters { get; set; }
    [JsonPropertyName("active_quarters")]
    public int ActiveQuarters { get; set; }
    public int[] Percentiles { get; set; }
}

public class PortfolioDto
{
    public string Name { get; set; }
    public List<AssetDto> Assets { get; set; }
    [JsonPropertyName("rebalancing_frequency")]
    public int RebalancingFrequency { get; set; }
    [JsonPropertyName("cash_asset_class_name")]
    public string CashAssetClassName { get; set; }
    [JsonPropertyName("portfolio_mgmt_fee")]
    public double PortfolioMgmtFee { get; set; }
    public bool Liquid { get; set; }
    [JsonPropertyName("capital_gain_tax_rate")]
    public double CapitalGainTaxRate { get; set; }
    [JsonPropertyName("income_tax_rate")]
    public double IncomeTaxRate { get; set; }
    [JsonPropertyName("max_credit_fraction")]
    public double MaxCreditFraction { get; set; }
}

public class AssetDto
{
    [JsonPropertyName("asset_class")]
    public string AssetClass { get; set; }
    [JsonPropertyName("initial_allocation")]
    public double InitialAllocation { get; set; }
    [JsonPropertyName("asset_mgmt_fee")]
    public double AssetMgmtFee { get; set; }
    [JsonPropertyName("initial_load_fee")]
    public double InitialLoadFee { get; set; }
}