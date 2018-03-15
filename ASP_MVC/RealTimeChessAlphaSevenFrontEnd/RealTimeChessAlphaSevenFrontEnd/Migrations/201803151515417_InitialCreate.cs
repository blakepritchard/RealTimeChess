namespace RealTimeChessAlphaSevenFrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChessMatches",
                c => new
                    {
                        ChessMatchId = c.Int(nullable: false, identity: true),
                        NumPlayers = c.Int(),
                        MatchStartTime = c.DateTime(),
                        MatchEndTime = c.DateTime(),
                        IsSetup = c.Boolean(),
                        HasStarted = c.Boolean(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                        Deleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.ChessMatchId);
            
            CreateTable(
                "dbo.MatchPlayers",
                c => new
                    {
                        MatchPlayerId = c.Int(nullable: false, identity: true),
                        ChessMatchId = c.Int(),
                        PlayerId = c.Int(),
                        PlayerTypeId = c.Int(),
                        WebClientUrl = c.String(),
                        IsDeleted = c.Boolean(),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                        Deleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.MatchPlayerId)
                .ForeignKey("dbo.PlayerTypes", t => t.PlayerTypeId)
                .ForeignKey("dbo.ChessMatches", t => t.ChessMatchId)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .Index(t => t.ChessMatchId)
                .Index(t => t.PlayerId)
                .Index(t => t.PlayerTypeId);
            
            CreateTable(
                "dbo.ChessPieces",
                c => new
                    {
                        ChessPieceId = c.Int(nullable: false, identity: true),
                        MatchPlayerId = c.Int(),
                        ChessPieceTypeId = c.Int(),
                        LocationX = c.Int(),
                        LocationY = c.Int(),
                        IsCaptured = c.Boolean(),
                        IsMoving = c.Boolean(),
                    })
                .PrimaryKey(t => t.ChessPieceId)
                .ForeignKey("dbo.ChessPieceTypes", t => t.ChessPieceTypeId)
                .ForeignKey("dbo.MatchPlayers", t => t.MatchPlayerId)
                .Index(t => t.MatchPlayerId)
                .Index(t => t.ChessPieceTypeId);
            
            CreateTable(
                "dbo.ChessPieceTypes",
                c => new
                    {
                        ChessPieceTypeId = c.Int(nullable: false, identity: true),
                        ChessPieceTypeName = c.String(),
                        ChessPieceScoreValue = c.Int(),
                        Velocity = c.Int(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ChessPieceTypeId);
            
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        MoveId = c.Int(nullable: false, identity: true),
                        ChessPieceId = c.Int(),
                        AlgebraicChessNotation = c.String(),
                        GameClockBeginMove = c.DateTime(),
                        GameClockEndMove = c.DateTime(),
                        PositionBeginX = c.Int(),
                        PositionBeginY = c.Int(),
                        PositionEndX = c.Int(),
                        PositionEndY = c.Int(),
                        PositionCurrentX = c.Double(),
                        PositionCurrentY = c.Double(),
                        Distance = c.Double(),
                        Velocity = c.Double(),
                        TravelTime = c.String(),
                        Heading = c.Double(),
                        HeadingSin = c.Double(),
                        HeadingCos = c.Double(),
                        IsDeleted = c.Boolean(),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                        Deleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.MoveId)
                .ForeignKey("dbo.ChessPieces", t => t.ChessPieceId)
                .Index(t => t.ChessPieceId);
            
            CreateTable(
                "dbo.PlayerTypes",
                c => new
                    {
                        PlayerTypeId = c.Int(nullable: false, identity: true),
                        PlayerTypeName = c.String(),
                        TurnOrder = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerTypeId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        AuthenticationId = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        NumWins = c.Int(),
                        NumLosses = c.Int(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                        Deleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MatchPlayers", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.MatchPlayers", "ChessMatchId", "dbo.ChessMatches");
            DropForeignKey("dbo.MatchPlayers", "PlayerTypeId", "dbo.PlayerTypes");
            DropForeignKey("dbo.ChessPieces", "MatchPlayerId", "dbo.MatchPlayers");
            DropForeignKey("dbo.Moves", "ChessPieceId", "dbo.ChessPieces");
            DropForeignKey("dbo.ChessPieces", "ChessPieceTypeId", "dbo.ChessPieceTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Moves", new[] { "ChessPieceId" });
            DropIndex("dbo.ChessPieces", new[] { "ChessPieceTypeId" });
            DropIndex("dbo.ChessPieces", new[] { "MatchPlayerId" });
            DropIndex("dbo.MatchPlayers", new[] { "PlayerTypeId" });
            DropIndex("dbo.MatchPlayers", new[] { "PlayerId" });
            DropIndex("dbo.MatchPlayers", new[] { "ChessMatchId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Players");
            DropTable("dbo.PlayerTypes");
            DropTable("dbo.Moves");
            DropTable("dbo.ChessPieceTypes");
            DropTable("dbo.ChessPieces");
            DropTable("dbo.MatchPlayers");
            DropTable("dbo.ChessMatches");
        }
    }
}
