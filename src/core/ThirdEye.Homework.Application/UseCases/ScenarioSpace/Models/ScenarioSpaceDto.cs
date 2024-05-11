using ThirdEye.Homework.Domain.Entities;

namespace ThirdEye.Homework.Application.UseCases.ScenarioSpace.Models;

public class ScenarioSpaceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public AssetClassCashType AssetClassCashType { get; set; }
    public int RequestCount { get; set; }
}