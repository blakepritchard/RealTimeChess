using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealTimeChessAlphaSeven.Migrations
{
    public partial class WebCLientUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebClientUrl",
                table: "tblMatchPlayers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebClientUrl",
                table: "tblMatchPlayers");
        }
    }
}
