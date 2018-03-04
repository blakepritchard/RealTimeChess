using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealTimeChessAlphaSeven.Migrations
{
    public partial class RefactoringMovesFromPlayerToPieces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMoves_tblMatchPlayers_MatchPlayerId",
                table: "tblMoves");

            migrationBuilder.RenameColumn(
                name: "MatchPlayerId",
                table: "tblMoves",
                newName: "ChessPieceId");

            migrationBuilder.RenameIndex(
                name: "IX_tblMoves_MatchPlayerId",
                table: "tblMoves",
                newName: "IX_tblMoves_ChessPieceId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMoves_tblChessPieces_ChessPieceId",
                table: "tblMoves",
                column: "ChessPieceId",
                principalTable: "tblChessPieces",
                principalColumn: "ChessPieceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMoves_tblChessPieces_ChessPieceId",
                table: "tblMoves");

            migrationBuilder.RenameColumn(
                name: "ChessPieceId",
                table: "tblMoves",
                newName: "MatchPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_tblMoves_ChessPieceId",
                table: "tblMoves",
                newName: "IX_tblMoves_MatchPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMoves_tblMatchPlayers_MatchPlayerId",
                table: "tblMoves",
                column: "MatchPlayerId",
                principalTable: "tblMatchPlayers",
                principalColumn: "MatchPlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
