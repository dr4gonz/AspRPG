using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspRPG.Migrations
{
    public partial class AddLevelAndExperienceToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_MonsterId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "Exp",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Exp",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_MonsterId",
                table: "Weapons",
                column: "MonsterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_MonsterId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Exp",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Exp",
                table: "Monsters");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_MonsterId",
                table: "Weapons",
                column: "MonsterId");
        }
    }
}
