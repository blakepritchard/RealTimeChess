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
    [Migration("20180218032538_SeedPlayerTypes")]
    partial class SeedPlayerTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("MatchEndTime");

                    b.Property<DateTime>("MatchStartTime");

                    b.Property<string>("PlayerTypeName");

                    b.Property<DateTime>("Updated");

                    b.HasKey("ChessMatchId")
                        .HasName("PK_ChessMatches");

                    b.ToTable("tblChessMatches");
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

                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.PlayerType")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RealTimeChessAlphaSeven.Models.RealTimeChessModels.Move", b =>
                {
                    b.HasOne("RealTimeChessAlphaSeven.Models.RealTimeChessModels.MatchPlayer")
                        .WithMany("Moves")
                        .HasForeignKey("MatchPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
