using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TexasRealTimeChess.Migrations
{
    public partial class CreateChessSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblChessMatches",
                columns: table => new
                {
                    ChessMatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MatchEndTime = table.Column<DateTime>(nullable: false),
                    MatchStartTime = table.Column<DateTime>(nullable: false),
                    PlayerTypeName = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessMatches", x => x.ChessMatchId);
                });

            migrationBuilder.CreateTable(
                name: "tblPlayers",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthenticationId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    NumLosses = table.Column<int>(nullable: false),
                    NumWins = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "tblPlayerTypes",
                columns: table => new
                {
                    PlayerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerTypeName = table.Column<string>(nullable: true),
                    TurnOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTypes", x => x.PlayerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblMatchPlayers",
                columns: table => new
                {
                    MatchPlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChessMatchId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    PlayerTypeId = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayers", x => x.MatchPlayerId);
                    table.ForeignKey(
                        name: "FK_tblMatchPlayers_tblChessMatches_ChessMatchId",
                        column: x => x.ChessMatchId,
                        principalTable: "tblChessMatches",
                        principalColumn: "ChessMatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMatchPlayers_tblPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "tblPlayers",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMatchPlayers_tblPlayerTypes_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "tblPlayerTypes",
                        principalColumn: "PlayerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMoves",
                columns: table => new
                {
                    MoveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlgebraicChessNotation = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    GameClockBeginMove = table.Column<DateTime>(nullable: false),
                    GameClockEndMove = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MatchPlayerId = table.Column<int>(nullable: false),
                    PlayerTypeName = table.Column<string>(nullable: true),
                    PositionBeginMove = table.Column<string>(nullable: true),
                    PositionEndMove = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_tblMoves_tblMatchPlayers_MatchPlayerId",
                        column: x => x.MatchPlayerId,
                        principalTable: "tblMatchPlayers",
                        principalColumn: "MatchPlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblMatchPlayers_ChessMatchId",
                table: "tblMatchPlayers",
                column: "ChessMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMatchPlayers_PlayerId",
                table: "tblMatchPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMatchPlayers_PlayerTypeId",
                table: "tblMatchPlayers",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMoves_MatchPlayerId",
                table: "tblMoves",
                column: "MatchPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMoves");

            migrationBuilder.DropTable(
                name: "tblMatchPlayers");

            migrationBuilder.DropTable(
                name: "tblChessMatches");

            migrationBuilder.DropTable(
                name: "tblPlayers");

            migrationBuilder.DropTable(
                name: "tblPlayerTypes");
        }
    }
}
