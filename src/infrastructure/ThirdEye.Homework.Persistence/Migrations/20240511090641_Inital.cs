using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThirdEye.Homework.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScenarioSpaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioSpaces", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ScenarioSpaces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10b739f5-5f5f-4d15-86a7-518f64e2e7c6"), "dvv_3a" },
                    { new Guid("4c84c258-c05e-4a1a-862c-b9134c2f64e7"), "default_2c" },
                    { new Guid("563d5378-ffa9-4675-be72-e3120ed3a759"), "chf_default_3a" },
                    { new Guid("7590b66e-59cf-463a-a55c-e187deeb9111"), "us_default_4b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScenarioSpaces");
        }
    }
}
