using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealTimeChessAlphaSeven.Models.RealTimeChessModels;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class RealTimeChessDbContext : DbContext
    {
        public DbSet<ChessMatch> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerType> PlayerTypes { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }
        public DbSet<RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessPieceType> ChessPieceType { get; set; }
        public DbSet<RealTimeChessAlphaSeven.Models.RealTimeChessModels.ChessPiece> ChessPiece { get; set; }


        public RealTimeChessDbContext() : base()
        {
        }

        public RealTimeChessDbContext(DbContextOptions<RealTimeChessDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("tblPlayers");
            modelBuilder.Entity<Player>().HasKey(b => b.PlayerId).HasName("PK_Players");

            modelBuilder.Entity<PlayerType>().ToTable("tblPlayerTypes");
            modelBuilder.Entity<PlayerType>().HasKey(b => b.PlayerTypeId).HasName("PK_PlayerTypes");

            modelBuilder.Entity<Move>().ToTable("tblMoves");
            modelBuilder.Entity<Move>().HasKey(b => b.MoveId).HasName("PK_Moves");

            modelBuilder.Entity<MatchPlayer>().ToTable("tblMatchPlayers");
            modelBuilder.Entity<MatchPlayer>().HasKey(b => b.MatchPlayerId).HasName("PK_MatchPlayers");

            modelBuilder.Entity<ChessMatch>().ToTable("tblChessMatches");
            modelBuilder.Entity<ChessMatch>().HasKey(b => b.ChessMatchId).HasName("PK_ChessMatches");

            modelBuilder.Entity<ChessPieceType>().ToTable("tblChessPieceTypes");
            modelBuilder.Entity<ChessPieceType>().HasKey(b => b.ChessPieceTypeId).HasName("PK_ChessPieceTypes");

            modelBuilder.Entity<ChessPiece>().ToTable("tblChessPieces");
            modelBuilder.Entity<ChessPiece>().HasKey(b => b.ChessPieceId).HasName("PK_ChessPieces");
        }
    }
}
