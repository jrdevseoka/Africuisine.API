using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace Africuisine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeSQLDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CulturalGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulturalGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CulturalGroupId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CulturalGroups_CulturalGroupId",
                        column: x => x.CulturalGroupId,
                        principalTable: "CulturalGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CulturalGroups",
                columns: new[] { "Id", "Creation", "LUserUpdate", "LastUpdate", "Name", "SeqNo" },
                values: new object[,]
                {
                    { "04d33c2e-fe8c-4600-bd4d-46ad8d86c5fd", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(558), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(559), "Indian", 0 },
                    { "1cb706f7-730f-43a8-8616-a24ca32826e4", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(419), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(420), "Venda", 0 },
                    { "2a5b27a1-65be-4a0a-bdb7-620cb1f65bb3", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(569), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(570), "Afrikaaner", 0 },
                    { "369dc868-f621-40ce-aad3-54bba2be2b8e", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(410), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(411), "Swazi", 0 },
                    { "36dc8713-5eca-45e6-895c-a3da20be0b3f", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(537), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(538), "Khoisan", 0 },
                    { "3ec01b27-7578-4a56-96d4-f41246a90774", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(424), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(424), "Tsonga", 0 },
                    { "3f17c686-cabe-4cea-bb2a-dfddc59ecac2", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(543), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(543), "Griqua", 0 },
                    { "4bf4eb45-2e94-48fd-a548-48145607e4cf", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(395), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(395), "Sotho", 0 },
                    { "5415b068-fe83-4229-9f77-3b64155542ed", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(564), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(564), "English", 0 },
                    { "843eaf24-bc1c-442b-a28a-5859e9eb749b", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(429), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(430), "Ndebele", 0 },
                    { "8e861f64-c30b-47dc-b12e-d546cfd17453", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(383), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(383), "Xhosa", 0 },
                    { "9b3a7db6-b330-4583-8140-0352ac6a8011", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(370), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(372), "Zulu", 0 },
                    { "a3b3fa07-fddb-4263-88f5-db1de384c961", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(434), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(435), "BaPedi", 0 },
                    { "f4db1989-7ef1-42b0-8561-de3fdd771b8f", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(389), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(390), "Tswana", 0 },
                    { "f877826e-5f05-4998-9ec0-bd90ad6bccac", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(548), "", new DateTime(2024, 3, 2, 19, 55, 0, 945, DateTimeKind.Utc).AddTicks(549), "Coloured", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Creation", "LUserUpdate", "LastUpdate", "Name", "NormalizedName", "SeqNo" },
                values: new object[,]
                {
                    { "108d0ef0-290d-4d08-a34f-9b181f0db61e", "6446d2d8-9813-4571-ab1c-9c5fb75c6103", new DateTime(2024, 3, 2, 19, 55, 0, 944, DateTimeKind.Utc).AddTicks(8327), "", new DateTime(2024, 3, 2, 19, 55, 0, 944, DateTimeKind.Utc).AddTicks(8328), "Mobile", "MOBILE", 0 },
                    { "a773c719-73e2-46a4-91d9-5ccd84b101fa", "39b6154d-2b7a-4b80-a7a6-0d24f77f86e4", new DateTime(2024, 3, 2, 19, 55, 0, 944, DateTimeKind.Utc).AddTicks(8272), "", new DateTime(2024, 3, 2, 19, 55, 0, 944, DateTimeKind.Utc).AddTicks(8277), "Administrator", "ADMINISTRATOR", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CulturalGroupId",
                table: "Users",
                column: "CulturalGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CulturalGroups");
        }
    }
}
