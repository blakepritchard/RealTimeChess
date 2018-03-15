﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RealTimeChessAlphaSeven.Models.RealTimeChessModels;
using System;

namespace RealTimeChessAlphaSeven.Migrations
{
    [DbContext(typeof(RealTimeChessDbContext))]
    partial class RealTimeChessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessMatch", b =>
                {
                    b.Property<int>("ChessMatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<bool>("HasStarted");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSetup");

                    b.Property<DateTime?>("MatchEndTime");

                    b.Property<DateTime>("MatchStartTime");

                    b.Property<int>("NumPlayers");

                    b.Property<DateTime>("Updated");

                    b.HasKey("ChessMatchId")
                        .HasName("PK_ChessMatches");

                    b.ToTable("tblChessMatches");
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessPiece", b =>
                {
                    b.Property<int>("ChessPieceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChessPieceTypeId");

                    b.Property<bool>("IsCaptured");

                    b.Property<bool>("IsMoving");

                    b.Property<int>("LocationX");

                    b.Property<int>("LocationY");

                    b.Property<int>("MatchPlayerId");

                    b.HasKey("ChessPieceId")
                        .HasName("PK_ChessPieces");

                    b.HasIndex("ChessPieceTypeId");

                    b.HasIndex("MatchPlayerId");

                    b.ToTable("tblChessPieces");
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessPieceType", b =>
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

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.MatchPlayer", b =>
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

                    b.Property<string>("WebClientUrl");

                    b.HasKey("MatchPlayerId")
                        .HasName("PK_MatchPlayers");

                    b.HasIndex("ChessMatchId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PlayerTypeId");

                    b.ToTable("tblMatchPlayers");
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.Move", b =>
                {
                    b.Property<int>("MoveId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlgebraicChessNotation");

                    b.Property<int>("ChessPieceId");

                    b.Property<DateTime?>("Created");

                    b.Property<DateTime?>("Deleted");

                    b.Property<double?>("Distance");

                    b.Property<DateTime>("GameClockBeginMove");

                    b.Property<DateTime?>("GameClockEndMove");

                    b.Property<float?>("Heading");

                    b.Property<float?>("HeadingCos");

                    b.Property<float?>("HeadingSin");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int>("PositionBeginX");

                    b.Property<int>("PositionBeginY");

                    b.Property<float?>("PositionCurrentX");

                    b.Property<float?>("PositionCurrentY");

                    b.Property<int>("PositionEndX");

                    b.Property<int>("PositionEndY");

                    b.Property<TimeSpan?>("TravelTime");

                    b.Property<DateTime?>("Updated");

                    b.Property<double?>("Velocity");

                    b.HasKey("MoveId")
                        .HasName("PK_Moves");

                    b.HasIndex("ChessPieceId");

                    b.ToTable("tblMoves");
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.Player", b =>
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

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.PlayerType", b =>
                {
                    b.Property<int>("PlayerTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlayerTypeName");

                    b.Property<int>("TurnOrder");

                    b.HasKey("PlayerTypeId")
                        .HasName("PK_PlayerTypes");

                    b.ToTable("tblPlayerTypes");
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessPiece", b =>
                {
                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessPieceType", "ChessPieceType")
                        .WithMany()
                        .HasForeignKey("ChessPieceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.MatchPlayer")
                        .WithMany("ChessPieces")
                        .HasForeignKey("MatchPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.MatchPlayer", b =>
                {
                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessMatch")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("ChessMatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.Player")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.PlayerType", "PlayerType")
                        .WithMany()
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.Move", b =>
                {
                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessPiece", "ChessPiece")
                        .WithMany("Moves")
                        .HasForeignKey("ChessPieceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
