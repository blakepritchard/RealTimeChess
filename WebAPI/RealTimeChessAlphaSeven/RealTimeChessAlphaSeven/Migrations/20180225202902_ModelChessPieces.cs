using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TexasRealTimeChess.Migrations
{
    public partial class ModelChessPieces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblChessPieces",
                columns: table => new
                {
                    ChessPieceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChessPieceTypeId = table.Column<int>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    Heading = table.Column<float>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    MatchPlayerId = table.Column<int>(nullable: false),
                    PositionX = table.Column<float>(nullable: false),
                    PositionY = table.Column<float>(nullable: false),
                    Velocity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessPieces", x => x.ChessPieceId);
                    table.ForeignKey(
                        name: "FK_tblChessPieces_tblMatchPlayers_MatchPlayerId",
                        column: x => x.MatchPlayerId,
                        principalTable: "tblMatchPlayers",
                        principalColumn: "MatchPlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblChessPieceTypes",
                columns: table => new
                {
                    ChessPieceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChessPieceScoreValue = table.Column<int>(nullable: false),
                    ChessPieceTypeName = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Velocity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessPieceTypes", x => x.ChessPieceTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblChessPieces_MatchPlayerId",
                table: "tblChessPieces",
                column: "MatchPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblChessPieces");

            migrationBuilder.DropTable(
                name: "tblChessPieceTypes");
        }
    }
}
