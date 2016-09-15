using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspRPG.Migrations
{
    public partial class AddPlayerToWeapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonsterId",
                table: "Weapons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Weapons");

            migrationBuilder.AlterColumn<int>(
                name: "MonsterId",
                table: "Weapons",
                nullable: false);
        }
    }
}
