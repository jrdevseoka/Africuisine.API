using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Africuisine.Infrastructure.Migrations.AfricuisineDb
{
    /// <inheritdoc />
    public partial class AddMeasurements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Abbreviation", "Creation", "Description", "LUserUpdate", "LastUpdate", "Name", "SeqNo" },
                values: new object[,]
                {
                    { "378e8c51-4863-4c98-a5ec-5168ece07f1b", "ml", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4613), "Used for liquids, such as water, milk, and oil", "", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4616), "Milliliter", 0 },
                    { "5a5be09d-bb2d-4344-8e73-9069aa4e14c4", "Tbsp", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4647), "Approximately 15 ml.", "", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4647), "Tablespoon", 0 },
                    { "6b15dfb3-0052-432f-a997-5d5e5186c6d5", "250 ml", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4650), "Used for both liquid and dry ingredients.", "", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4651), "Cup", 0 },
                    { "aadbe41b-2767-47cd-8abf-f018fde726d8", "kg", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4636), "Larger mass measurements, especially for bulk ingredients.", "", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4637), "Kilograms", 0 },
                    { "c11269c6-1577-4dc6-8a97-e8cd75abe4f1", "g", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4627), "Common unit for measuring dry ingredients like flour, sugar, and spices.", "", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4628), "Grams", 0 },
                    { "e447a70a-876f-4ec5-9ae2-0820caa3bdb9", "tsp.", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4640), "Approximately 5 ml.", "", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4641), "Teaspoon", 0 },
                    { "e882efa6-d01d-4f70-b1cb-6c30c5557123", "l", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4623), "Larger volume measurements, often used for bulk liquids.", "", new DateTime(2024, 3, 3, 17, 34, 10, 789, DateTimeKind.Local).AddTicks(4623), "Liters", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_Name",
                table: "Measurements",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
