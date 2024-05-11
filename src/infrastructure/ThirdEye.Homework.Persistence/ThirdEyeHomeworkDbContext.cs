using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThirdEye.Homework.Domain.Entities;

namespace ThirdEye.Homework.Persistence;

public class ThirdEyeHomeworkDbContext : DbContext
{
    public ThirdEyeHomeworkDbContext(DbContextOptions options): base(options) { }
    
    public DbSet<ScenarioSpace> ScenarioSpaces { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ScenarioSpace>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.AssetClassCashType).HasConversion(new EnumToStringConverter<AssetClassCashType>());
        });
        
        Seed(modelBuilder);
    }
    
    private void Seed(ModelBuilder modelBuilder)
    {
        var scenarioSpace1 = new ScenarioSpace()
        {
            Id = new Guid("4C84C258-C05E-4A1A-862C-B9134C2F64E7"),
            Name = "default_2c",
            AssetClassCashType = AssetClassCashType.CS_EUR,
            RequestCount = 0
        };

        var scenarioSpace2 = new ScenarioSpace()
        {
            Id = new Guid("563D5378-FFA9-4675-BE72-E3120ED3A759"),
            Name = "chf_default_3a",
            AssetClassCashType = AssetClassCashType.CS_CHF,
            RequestCount = 0
        };
        
        var scenarioSpace3 = new ScenarioSpace()
        {
            Id = new Guid("7590B66E-59CF-463A-A55C-E187DEEB9111"),
            Name = "us_default_4b",
            AssetClassCashType = AssetClassCashType.CS_USD,
            RequestCount = 0
        };
        
        var scenarioSpace4 = new ScenarioSpace()
        {
            Id = new Guid("10B739F5-5F5F-4D15-86A7-518F64E2E7C6"),
            Name = "dvv_3a",
            AssetClassCashType = AssetClassCashType.CS_EUR,
            RequestCount = 0
        };

        modelBuilder.Entity<ScenarioSpace>().HasData(
            scenarioSpace1,
            scenarioSpace2,
            scenarioSpace3,
            scenarioSpace4);
    }
}