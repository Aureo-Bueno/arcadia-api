using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArcadiaApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperHero",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SuperHeroId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_SuperHero_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Power",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SuperPower = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SuperHeroId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Power_SuperHero_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SuperHero",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("253a3137-0404-4274-a15f-bcf608ce8a71"), "Superman is a fictional superhero. The character was created by writer Jerry Siegel and artist Joe Shuster, and first appeared in the comic book Action Comics #1 (cover-dated June 1938 and published April 18, 1938).", "Superman" },
                    { new Guid("2968f15c-fa74-4058-b790-3feec7934faf"), "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger,[2][3] and first appeared in Detective Comics #27 (May 1939).", "Batman" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "SuperHeroId", "Title" },
                values: new object[,]
                {
                    { new Guid("a2db1d07-5491-4b22-bf67-417f079340bc"), "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger,[2][3] and first appeared in Detective Comics #27 (May 1939).", new Guid("2968f15c-fa74-4058-b790-3feec7934faf"), "Batman" },
                    { new Guid("ef2399b0-3292-4aa5-a157-e498d70c8786"), "Superman is a fictional superhero. The character was created by writer Jerry Siegel and artist Joe Shuster, and first appeared in the comic book Action Comics #1 (cover-dated June 1938 and published April 18, 1938).", new Guid("253a3137-0404-4274-a15f-bcf608ce8a71"), "Superman" }
                });

            migrationBuilder.InsertData(
                table: "Power",
                columns: new[] { "Id", "Description", "SuperHeroId", "SuperPower" },
                values: new object[,]
                {
                    { new Guid("1c6c0a5d-dbb3-489d-9a9c-d851673ccbbf"), "Superman's powers include incredible strength, the ability to fly, and invulnerability.", new Guid("253a3137-0404-4274-a15f-bcf608ce8a71"), "Superhuman strength, speed, stamina and durability" },
                    { new Guid("fce10a99-29d4-408f-962e-78b079ca69c8"), "Batman's primary character traits can be summarized as \"wealthy, physical prowess, deductive abilities and obsession\".", new Guid("2968f15c-fa74-4058-b790-3feec7934faf"), "Genius-level intellect" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_SuperHeroId",
                table: "Movie",
                column: "SuperHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Power_SuperHeroId",
                table: "Power",
                column: "SuperHeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropTable(
                name: "SuperHero");
        }
    }
}
