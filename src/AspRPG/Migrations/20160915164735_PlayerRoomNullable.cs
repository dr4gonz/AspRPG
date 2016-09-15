using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspRPG.Migrations
{
    public partial class PlayerRoomNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Locations_CurrentRoomId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentRoomId",
                table: "Players",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Locations_CurrentRoomId",
                table: "Players",
                column: "CurrentRoomId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Locations_CurrentRoomId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentRoomId",
                table: "Players",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Locations_CurrentRoomId",
                table: "Players",
                column: "CurrentRoomId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
