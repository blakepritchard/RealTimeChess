﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using TexasRealTimeChess.Models.RealTimeChessModels;
using System;

namespace TexasRealTimeChess.Migrations
{
    [DbContext(typeof(RealTimeChessDbContext))]
    [Migration("20180228000410_ChessPieceCoordinates")]
    partial class ChessPieceCoordinates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.ChessMatch", b =>
                {
                    b.Property<int>("ChessMatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("MatchEndTime");

                    b.Property<DateTime>("MatchStartTime");

                    b.Property<int>("NumPlayers");

                    b.Property<DateTime>("Updated");

                    b.HasKey("ChessMatchId")
                        .HasName("PK_ChessMatches");

                    b.ToTable("tblChessMatches");
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.ChessPiece", b =>
                {
                    b.Property<int>("ChessPieceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChessPieceTypeId");

                    b.Property<string>("DestinationCoordinates");

                    b.Property<float>("Heading");

                    b.Property<bool>("IsMoving");

                    b.Property<string>("LocationCoordinates");

                    b.Property<string>("LocationFileLetter");

                    b.Property<int>("LocationRankNum");

                    b.Property<int>("MatchPlayerId");

                    b.Property<float>("PositionX");

                    b.Property<float>("PositionY");

                    b.Property<float>("Velocity");

                    b.HasKey("ChessPieceId")
                        .HasName("PK_ChessPieces");

                    b.HasIndex("MatchPlayerId");

                    b.ToTable("tblChessPieces");
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.ChessPieceType", b =>
                {
                    b.Property<int>("ChessPieceTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChessPieceScoreValue");

                    b.Property<string>("ChessPieceTypeName");

                    b.Property<string>("ImagePath");

                    b.Property<int>("Velocity");

                    b.HasKey("ChessPieceTypeId")
                        .HasName("PK_ChessPieceTypes");

                    b.ToTable("tblChessPieceTypes");
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.MatchPlayer", b =>
                {
                    b.Property<int>("MatchPlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChessMatchId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PlayerId");

                    b.Property<int>("PlayerTypeId");

                    b.Property<DateTime>("Updated");

                    b.HasKey("MatchPlayerId")
                        .HasName("PK_MatchPlayers");

                    b.HasIndex("ChessMatchId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PlayerTypeId");

                    b.ToTable("tblMatchPlayers");
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.Move", b =>
                {
                    b.Property<int>("MoveId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlgebraicChessNotation");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<DateTime>("GameClockBeginMove");

                    b.Property<DateTime>("GameClockEndMove");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MatchPlayerId");

                    b.Property<string>("PlayerTypeName");

                    b.Property<string>("PositionBeginMove");

                    b.Property<string>("PositionEndMove");

                    b.Property<DateTime>("Updated");

                    b.HasKey("MoveId")
                        .HasName("PK_Moves");

                    b.HasIndex("MatchPlayerId");

                    b.ToTable("tblMoves");
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthenticationId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<int>("NumLosses");

                    b.Property<int>("NumWins");

                    b.Property<DateTime>("Updated");

                    b.HasKey("PlayerId")
                        .HasName("PK_Players");

                    b.ToTable("tblPlayers");
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.PlayerType", b =>
                {
                    b.Property<int>("PlayerTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlayerTypeName");

                    b.Property<int>("TurnOrder");

                    b.HasKey("PlayerTypeId")
                        .HasName("PK_PlayerTypes");

                    b.ToTable("tblPlayerTypes");
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.ChessPiece", b =>
                {
                    b.HasOne("TexasRealTimeChess.Models.RealTimeChessModels.MatchPlayer")
                        .WithMany("Pieces")
                        .HasForeignKey("MatchPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.MatchPlayer", b =>
                {
                    b.HasOne("TexasRealTimeChess.Models.RealTimeChessModels.ChessMatch")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("ChessMatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TexasRealTimeChess.Models.RealTimeChessModels.Player")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TexasRealTimeChess.Models.RealTimeChessModels.PlayerType")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TexasRealTimeChess.Models.RealTimeChessModels.Move", b =>
                {
                    b.HasOne("TexasRealTimeChess.Models.RealTimeChessModels.MatchPlayer")
                        .WithMany("Moves")
                        .HasForeignKey("MatchPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
