using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArcadiaApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTeamAndVillain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "power_level",
                table: "SuperHero",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Villain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    power_level = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villain", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TeamSuperHero",
                columns: table => new
                {
                    team_id = table.Column<Guid>(type: "uuid", nullable: false),
                    super_hero_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSuperHero", x => new { x.team_id, x.super_hero_id });
                    table.ForeignKey(
                        name: "FK_TeamSuperHero_SuperHero_super_hero_id",
                        column: x => x.super_hero_id,
                        principalTable: "SuperHero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSuperHero_Team_team_id",
                        column: x => x.team_id,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamVillain",
                columns: table => new
                {
                    team_id = table.Column<Guid>(type: "uuid", nullable: false),
                    villain_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamVillain", x => new { x.team_id, x.villain_id });
                    table.ForeignKey(
                        name: "FK_TeamVillain_Team_team_id",
                        column: x => x.team_id,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamVillain_Villain_villain_id",
                        column: x => x.villain_id,
                        principalTable: "Villain",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SuperHero",
                keyColumn: "id",
                keyValue: new Guid("253a3137-0404-4274-a15f-bcf608ce8a71"),
                column: "power_level",
                value: 95);

            migrationBuilder.UpdateData(
                table: "SuperHero",
                keyColumn: "id",
                keyValue: new Guid("2968f15c-fa74-4058-b790-3feec7934faf"),
                column: "power_level",
                value: 85);

            migrationBuilder.InsertData(
                table: "Villain",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "power_level", "updated_at" },
                values: new object[,]
                {
                    { new Guid("1d7b30f3-72d4-43b1-a9f9-1630f4fd63be"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "A chaotic criminal mastermind and Batman's most infamous foe.", "Joker", 80, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("6e3c7e69-6c1d-4b04-9de3-3c62d0a31622"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "A genius industrialist and Superman's most dangerous rival.", "Lex Luthor", 88, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamSuperHero_super_hero_id",
                table: "TeamSuperHero",
                column: "super_hero_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamVillain_villain_id",
                table: "TeamVillain",
                column: "villain_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamSuperHero");

            migrationBuilder.DropTable(
                name: "TeamVillain");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Villain");

            migrationBuilder.DropColumn(
                name: "power_level",
                table: "SuperHero");
        }
    }
}
