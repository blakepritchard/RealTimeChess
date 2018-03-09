using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealTimeChessAlphaSeven.Migrations
{
    public partial class LinkChessPieceTypeToChessPieces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblChessPieces_ChessPieceTypeId",
                table: "tblChessPieces",
                column: "ChessPieceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblChessPieces_tblChessPieceTypes_ChessPieceTypeId",
                table: "tblChessPieces",
                column: "ChessPieceTypeId",
                principalTable: "tblChessPieceTypes",
                principalColumn: "ChessPieceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblChessPieces_tblChessPieceTypes_ChessPieceTypeId",
                table: "tblChessPieces");

            migrationBuilder.DropIndex(
                name: "IX_tblChessPieces_ChessPieceTypeId",
                table: "tblChessPieces");
        }
    }
}
