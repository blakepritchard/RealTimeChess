using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TexasRealTimeChess.Migrations
{
    public partial class ChessPieceCoordinateTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationCoordinates",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "LocationFileLetter",
                table: "tblChessPieces");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DestinationFileNum",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationRankNum",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "HeadingCos",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HeadingSin",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "LocationFileNum",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "DestinationFileNum",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "DestinationRankNum",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "HeadingCos",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "HeadingSin",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "LocationFileNum",
                table: "tblChessPieces");

            migrationBuilder.AddColumn<string>(
                name: "LocationCoordinates",
                table: "tblChessPieces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationFileLetter",
                table: "tblChessPieces",
                nullable: true);
        }
    }
}
