using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TexasRealTimeChess.Migrations
{
    public partial class RefactoringMoveParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerTypeName",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionBeginMove",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionEndMove",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "DestinationCoordinates",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "DestinationFileNum",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "DestinationRankNum",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "Heading",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "HeadingCos",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "HeadingSin",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "PositionX",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "PositionY",
                table: "tblChessPieces");

            migrationBuilder.DropColumn(
                name: "Velocity",
                table: "tblChessPieces");

            migrationBuilder.RenameColumn(
                name: "LocationRankNum",
                table: "tblChessPieces",
                newName: "LocationY");

            migrationBuilder.RenameColumn(
                name: "LocationFileNum",
                table: "tblChessPieces",
                newName: "LocationX");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GameClockEndMove",
                table: "tblMoves",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GameClockBeginMove",
                table: "tblMoves",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<double>(
                name: "Distance",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Heading",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HeadingCos",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HeadingSin",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionBeginX",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionBeginY",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PositionCurrentX",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PositionCurrentY",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionEndX",
                table: "tblMoves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionEndY",
                table: "tblMoves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TravelTime",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Velocity",
                table: "tblMoves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "Heading",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "HeadingCos",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "HeadingSin",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionBeginX",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionBeginY",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionCurrentX",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionCurrentY",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionEndX",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "PositionEndY",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "TravelTime",
                table: "tblMoves");

            migrationBuilder.DropColumn(
                name: "Velocity",
                table: "tblMoves");

            migrationBuilder.RenameColumn(
                name: "LocationY",
                table: "tblChessPieces",
                newName: "LocationRankNum");

            migrationBuilder.RenameColumn(
                name: "LocationX",
                table: "tblChessPieces",
                newName: "LocationFileNum");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GameClockEndMove",
                table: "tblMoves",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GameClockBeginMove",
                table: "tblMoves",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayerTypeName",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionBeginMove",
                table: "tblMoves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionEndMove",
                table: "tblMoves",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "DestinationCoordinates",
                table: "tblChessPieces",
                nullable: true);

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
                name: "Heading",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0f);

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

            migrationBuilder.AddColumn<float>(
                name: "PositionX",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PositionY",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Velocity",
                table: "tblChessPieces",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
