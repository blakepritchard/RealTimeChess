using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealTimeChessAlphaSeven.Migrations
{
    public partial class ChessMatchNumPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerTypeName",
                table: "tblChessMatches");

            migrationBuilder.AddColumn<int>(
                name: "NumPlayers",
                table: "tblChessMatches",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumPlayers",
                table: "tblChessMatches");

            migrationBuilder.AddColumn<string>(
                name: "PlayerTypeName",
                table: "tblChessMatches",
                nullable: true);
        }
    }
}
