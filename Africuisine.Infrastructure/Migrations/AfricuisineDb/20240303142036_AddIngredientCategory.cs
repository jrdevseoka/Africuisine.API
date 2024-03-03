using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Africuisine.Infrastructure.Migrations.AfricuisineDb
{
    /// <inheritdoc />
    public partial class AddIngredientCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "Creation", "LUserUpdate", "LastUpdate", "Name", "SeqNo" },
                values: new object[,]
                {
                    { "27f4ff9c-df4e-461b-b493-945bb13843d0", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5689), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5690), "Condiments And Sauces", 0 },
                    { "2ca0594b-72ce-43bc-a026-585253c84c63", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5674), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5675), "Dairy And Dairy Alternatives", 0 },
                    { "36a04cd6-244b-4bfe-bc60-a31f844b8949", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5721), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5721), "Baking Ingredients", 0 },
                    { "494375ab-c69d-413c-aa0c-b0ec45c6c348", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5562), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5571), "Proteins", 0 },
                    { "62284ba5-98ea-4c0f-b4b1-eda5334450ef", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5734), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5734), "Nuts And Seeds", 0 },
                    { "75367eda-12d2-41d6-b71b-082d75cf9f84", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5644), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5645), "Fruits", 0 },
                    { "9036acae-e29e-4a2d-80e2-afaa12366ef8", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5637), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5637), "Vegetables And Herbs", 0 },
                    { "95014bf6-fa7a-4892-8bf8-d91527df7b34", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5741), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5741), "Beverages", 0 },
                    { "b5719323-1d85-44c4-b4a8-2707becb568f", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5658), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5659), "Grains And Starches", 0 },
                    { "f282bc7f-3c63-43f6-b8b6-6b95e8a9f5fe", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5702), "", new DateTime(2024, 3, 3, 16, 20, 36, 21, DateTimeKind.Local).AddTicks(5702), "Spices And Seasonings", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCategories_Name",
                table: "IngredientCategories",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientCategories");
        }
    }
}
