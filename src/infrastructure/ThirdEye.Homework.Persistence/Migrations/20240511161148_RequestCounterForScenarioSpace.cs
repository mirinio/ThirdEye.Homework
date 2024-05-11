using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirdEye.Homework.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RequestCounterForScenarioSpace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestCount",
                table: "ScenarioSpaces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("10b739f5-5f5f-4d15-86a7-518f64e2e7c6"),
                column: "RequestCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("4c84c258-c05e-4a1a-862c-b9134c2f64e7"),
                column: "RequestCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("563d5378-ffa9-4675-be72-e3120ed3a759"),
                column: "RequestCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ScenarioSpaces",
                keyColumn: "Id",
                keyValue: new Guid("7590b66e-59cf-463a-a55c-e187deeb9111"),
                column: "RequestCount",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestCount",
                table: "ScenarioSpaces");
        }
    }
}
