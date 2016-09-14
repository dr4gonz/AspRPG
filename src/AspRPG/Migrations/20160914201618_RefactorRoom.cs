using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspRPG.Migrations
{
    public partial class RefactorRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomEId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RoomNId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RoomSId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RoomWId",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Maps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EastDoor",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRoom",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NorthDoor",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SouthDoor",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WestDoor",
                table: "Locations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "EastDoor",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HasRoom",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "NorthDoor",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "SouthDoor",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "WestDoor",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "RoomEId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomNId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomSId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomWId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }
    }
}
