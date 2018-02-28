using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealTimeChessAlphaSeven.Migrations
{
    public partial class ChessPieceCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "tblChessPieces",
                newName: "LocationFileLetter");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "tblChessPieces",
                newName: "LocationCoordinates");

            migrationBuilder.AddColumn<string>(
                name: "DestinationCoordinates",
                table: "tblChessPieces",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMoving",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LocationRankNum",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationCoordinates",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "IsMoving",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "LocationRankNum",
                table: "tblChessPieces");

            migrationBuilder.RenameColumn(
                name: "LocationFileLetter",
                table: "tblChessPieces",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "LocationCoordinates",
                table: "tblChessPieces",
                newName: "Destination");
        }
    }
}
