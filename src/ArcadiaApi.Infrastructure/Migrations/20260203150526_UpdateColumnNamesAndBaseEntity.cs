using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcadiaApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNamesAndBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_SuperHero_SuperHeroId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Power_SuperHero_SuperHeroId",
                table: "Power");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SuperHero",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SuperHero",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SuperHero",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Power",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Power",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SuperPower",
                table: "Power",
                newName: "super_power");

            migrationBuilder.RenameColumn(
                name: "SuperHeroId",
                table: "Power",
                newName: "super_hero_id");

            migrationBuilder.RenameIndex(
                name: "IX_Power_SuperHeroId",
                table: "Power",
                newName: "IX_Power_super_hero_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movie",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Movie",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SuperHeroId",
                table: "Movie",
                newName: "super_hero_id");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_SuperHeroId",
                table: "Movie",
                newName: "IX_Movie_super_hero_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "SuperHero",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "SuperHero",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "SuperHero",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Power",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "Power",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Power",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Movie",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "Movie",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Movie",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "id",
                keyValue: new Guid("a2db1d07-5491-4b22-bf67-417f079340bc"),
                columns: new[] { "created_at", "deleted_at", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "id",
                keyValue: new Guid("ef2399b0-3292-4aa5-a157-e498d70c8786"),
                columns: new[] { "created_at", "deleted_at", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Power",
                keyColumn: "id",
                keyValue: new Guid("1c6c0a5d-dbb3-489d-9a9c-d851673ccbbf"),
                columns: new[] { "created_at", "deleted_at", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Power",
                keyColumn: "id",
                keyValue: new Guid("fce10a99-29d4-408f-962e-78b079ca69c8"),
                columns: new[] { "created_at", "deleted_at", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SuperHero",
                keyColumn: "id",
                keyValue: new Guid("253a3137-0404-4274-a15f-bcf608ce8a71"),
                columns: new[] { "created_at", "deleted_at", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "SuperHero",
                keyColumn: "id",
                keyValue: new Guid("2968f15c-fa74-4058-b790-3feec7934faf"),
                columns: new[] { "created_at", "deleted_at", "updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_SuperHero_super_hero_id",
                table: "Movie",
                column: "super_hero_id",
                principalTable: "SuperHero",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Power_SuperHero_super_hero_id",
                table: "Power",
                column: "super_hero_id",
                principalTable: "SuperHero",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_SuperHero_super_hero_id",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Power_SuperHero_super_hero_id",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "SuperHero");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "SuperHero");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "SuperHero");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "SuperHero",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "SuperHero",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SuperHero",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Power",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Power",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "super_power",
                table: "Power",
                newName: "SuperPower");

            migrationBuilder.RenameColumn(
                name: "super_hero_id",
                table: "Power",
                newName: "SuperHeroId");

            migrationBuilder.RenameIndex(
                name: "IX_Power_super_hero_id",
                table: "Power",
                newName: "IX_Power_SuperHeroId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Movie",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Movie",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movie",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "super_hero_id",
                table: "Movie",
                newName: "SuperHeroId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_super_hero_id",
                table: "Movie",
                newName: "IX_Movie_SuperHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_SuperHero_SuperHeroId",
                table: "Movie",
                column: "SuperHeroId",
                principalTable: "SuperHero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Power_SuperHero_SuperHeroId",
                table: "Power",
                column: "SuperHeroId",
                principalTable: "SuperHero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
