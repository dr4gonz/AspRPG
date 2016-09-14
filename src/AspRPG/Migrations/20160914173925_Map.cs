using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspRPG.Migrations
{
    public partial class Map : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "MapId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapId",
                table: "Locations",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Maps_MapId",
                table: "Locations",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Maps_MapId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MapId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Maps");
        }
    }
}
