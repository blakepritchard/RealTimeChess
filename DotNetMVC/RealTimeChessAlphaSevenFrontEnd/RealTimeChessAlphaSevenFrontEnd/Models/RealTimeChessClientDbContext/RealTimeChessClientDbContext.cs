using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


// Your context has been configured to use a 'OpponentMoveNotification' connection string from your application's 
// configuration file (App.config or Web.config). By default, this connection string targets the 
// 'RealTimeChessAlphaSevenFrontEnd.Models.RealTimeChessClientModels.OpponentMoveNotification' database on your LocalDb instance. 
// 
// If you wish to target a different database and/or database provider, modify the 'OpponentMoveNotification' 
// connection string in the application configuration file.
// Add a DbSet for each entity type that you want to include in your model. For more information 
// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

// public virtual DbSet<MyEntity> MyEntities { get; set; }


namespace RealTimeChessAlphaSevenFrontEnd.Models.RealTimeChessClientModels
{
    public class RealTimeChessClientDbContext : DbContext
    {

        public DbSet<ChessMatch> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerType> PlayerTypes { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }
        public DbSet<ChessPieceType> ChessPieceType { get; set; }
        public DbSet<ChessPiece> ChessPiece { get; set; }

        public RealTimeChessClientDbContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("tblPlayers");
            modelBuilder.Entity<Player>().HasKey(b => b.PlayerId);

            modelBuilder.Entity<PlayerType>().ToTable("tblPlayerTypes");
            modelBuilder.Entity<PlayerType>().HasKey(b => b.PlayerTypeId);

            modelBuilder.Entity<Move>().ToTable("tblMoves");
            modelBuilder.Entity<Move>().HasKey(b => b.MoveId);

            modelBuilder.Entity<MatchPlayer>().ToTable("tblMatchPlayers");
            modelBuilder.Entity<MatchPlayer>().HasKey(b => b.MatchPlayerId);

            modelBuilder.Entity<ChessMatch>().ToTable("tblChessMatches");
            modelBuilder.Entity<ChessMatch>().HasKey(b => b.ChessMatchId);

            modelBuilder.Entity<ChessPieceType>().ToTable("tblChessPieceTypes");
            modelBuilder.Entity<ChessPieceType>().HasKey(b => b.ChessPieceTypeId);

            modelBuilder.Entity<ChessPiece>().ToTable("tblChessPieces");
            modelBuilder.Entity<ChessPiece>().HasKey(b => b.ChessPieceId);
        }


    }

}