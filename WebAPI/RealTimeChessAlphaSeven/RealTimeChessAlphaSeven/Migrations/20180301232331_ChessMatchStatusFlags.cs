using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TexasRealTimeChess.Migrations
{
    public partial class ChessMatchStatusFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasStarted",
                table: "tblChessMatches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSetup",
                table: "tblChessMatches",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasStarted",
                table: "tblChessMatches");

            migrationBuilder.DropColumn(
                name: "IsSetup",
                table: "tblChessMatches");
        }
    }
}
