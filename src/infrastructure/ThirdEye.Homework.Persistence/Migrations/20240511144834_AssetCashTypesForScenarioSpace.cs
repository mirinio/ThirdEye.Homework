using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirdEye.Homework.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AssetCashTypesForScenarioSpace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssetClassCashType",
                table: "ScenarioSpaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("10b739f5-5f5f-4d15-86a7-518f64e2e7c6"),
                column: "AssetClassCashType",
                value: "CS_EUR");

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("4c84c258-c05e-4a1a-862c-b9134c2f64e7"),
                column: "AssetClassCashType",
                value: "CS_EUR");

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("563d5378-ffa9-4675-be72-e3120ed3a759"),
                column: "AssetClassCashType",
                value: "CS_CHF");

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("7590b66e-59cf-463a-a55c-e187deeb9111"),
                column: "AssetClassCashType",
                value: "CS_USD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetClassCashType",
                table: "ScenarioSpaces");
        }
    }
}
