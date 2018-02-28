using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class MatchPlayer
    {
        public MatchPlayer()
        {
            Pieces = new List<ChessPiece>();
            Moves = new List<Move>();

        }

        public int MatchPlayerId { get; set; }
        public int ChessMatchId { get; set; }
        public int PlayerId { get; set; }
        public int PlayerTypeId { get; set; }

        public List<ChessPiece> Pieces { get; set; }
        public List<Move> Moves { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public bool SetUpChessPieces(RealTimeChessDbContext context, int nNumPlayers, int nBoardWidth, int nBoardHeight)
        {
            bool bSuccess = true;

            if (2 == nNumPlayers)
            {
                switch (PlayerTypeId)
                {
                    case 1:
                        SetPawnRow(context, 2, nBoardWidth);
                        SetRoyalRow(context, 1, nBoardWidth);
                        break;
                    case 2:
                        SetPawnRow(context, 7, nBoardWidth);
                        SetRoyalRow(context, 8, nBoardWidth);
                        break;
                    case 3:
                        SetPawnColumn(context, "b", nBoardHeight);
                        SetRoyalColumn(context, "a", nBoardHeight);
                        break;
                    case 4:
                        SetPawnColumn(context, "k", nBoardHeight);
                        SetRoyalColumn(context, "l", nBoardHeight);
                        break;

                }
            }
            return bSuccess;

        }



        public void SetRoyalRow(RealTimeChessDbContext context, int nRankNumber, int nBoardWidth)
        {
            int nTypeIdKing = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "King").ChessPieceTypeId;
            int nTypeIdQueen = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Queen").ChessPieceTypeId;
            int nTypeIdBishop = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Bishop").ChessPieceTypeId;
            int nKTypeIdKnight = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "King").ChessPieceTypeId;
            int nTypeIdRook = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Rook").ChessPieceTypeId;

            ChessPiece RookLeft     = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, nRankNumber, "a")).Entity;
            ChessPiece KnightLeft   = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, nRankNumber, "b")).Entity;
            ChessPiece BishopLeft   = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, nRankNumber, "c")).Entity;
            ChessPiece King         = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdKing, nRankNumber, "d")).Entity;
            ChessPiece Queen        = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdQueen, nRankNumber, "e")).Entity;
            ChessPiece BishopRight  = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, nRankNumber, "f")).Entity;
            ChessPiece KnightRight  = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, nRankNumber, "g")).Entity;
            ChessPiece RookRight    = context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, nRankNumber, "h")).Entity;
            context.SaveChanges();
    }

        public  void SetRoyalColumn(RealTimeChessDbContext context, string strFileLetter, int nBoardWidth)
        {
            int nTypeIdKing = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "King")).ChessPieceTypeId;
            int nTypeIdQueen = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Queen")).ChessPieceTypeId;
            int nTypeIdBishop = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Bishop")).ChessPieceTypeId;
            int nKTypeIdKnight = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "King")).ChessPieceTypeId;
            int nTypeIdRook = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Rook")).ChessPieceTypeId;

            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, 8, strFileLetter));       // ChessPiece RookLeft
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, 7, strFileLetter));    // ChessPiece KnightLeft
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, 6, strFileLetter));     // ChessPiece BishopLeft
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdKing, 5, strFileLetter));       // ChessPiece King
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdQueen, 4, strFileLetter));       // ChessPiece Queen
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, 3, strFileLetter));     // ChessPiece BishopRight
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, 2, strFileLetter));    // ChessPiece KnightRight
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, 1, strFileLetter));       // ChessPiece RookRight
            context.SaveChanges();
        }

        public void SetPawnRow(RealTimeChessDbContext context, int nRankNumber, int nBoardWidth )
        {
            ChessPieceType typePawn = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Pawn");
            int nPawnTypeId = typePawn.ChessPieceTypeId;
            for (char c='a'; c<'i'; c++)
            {
                ChessPiece pawn = new ChessPiece(this.MatchPlayerId, nPawnTypeId, nRankNumber, c.ToString());
                context.ChessPiece.Add(pawn);
            }
            context.SaveChanges();
        }

        public void SetPawnColumn(RealTimeChessDbContext context, string strFileLetter, int nBoardHeight)
        {
            ChessPieceType typePawn = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Pawn");
            int nPawnTypeId = typePawn.ChessPieceTypeId;
            for (char i = '1'; i < 9; i++)
            {
                ChessPiece pawn = new ChessPiece(this.MatchPlayerId, nPawnTypeId, i, strFileLetter);
                context.ChessPiece.Add(pawn);
            }
            context.SaveChanges();
        }




    }
}
