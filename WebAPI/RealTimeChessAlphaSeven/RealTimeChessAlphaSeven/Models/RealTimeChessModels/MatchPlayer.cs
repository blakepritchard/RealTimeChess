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
                        SetPawnColumn(context, 2, nBoardHeight);
                        SetRoyalColumn(context, 1, nBoardHeight);
                        break;
                    case 4:
                        SetPawnColumn(context, 7, nBoardHeight);
                        SetRoyalColumn(context, 8, nBoardHeight);
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

            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, nRankNumber, 8));
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, nRankNumber, 7));
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, nRankNumber, 6));
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdKing, nRankNumber, 5));
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdQueen, nRankNumber, 4));
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, nRankNumber, 3));
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, nRankNumber, 2));
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, nRankNumber, 1));
            context.SaveChanges();
    }

        public  void SetRoyalColumn(RealTimeChessDbContext context, int nFileNum, int nBoardWidth)
        {
            int nTypeIdKing = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "King")).ChessPieceTypeId;
            int nTypeIdQueen = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Queen")).ChessPieceTypeId;
            int nTypeIdBishop = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Bishop")).ChessPieceTypeId;
            int nKTypeIdKnight = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "King")).ChessPieceTypeId;
            int nTypeIdRook = ( context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Rook")).ChessPieceTypeId;

            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, 8, nFileNum));       // ChessPiece RookLeft
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, 7, nFileNum));    // ChessPiece KnightLeft
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, 6, nFileNum));     // ChessPiece BishopLeft
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdKing, 5, nFileNum));       // ChessPiece King
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdQueen, 4, nFileNum));       // ChessPiece Queen
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdBishop, 3, nFileNum));     // ChessPiece BishopRight
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nKTypeIdKnight, 2, nFileNum));    // ChessPiece KnightRight
            context.ChessPiece.Add(new ChessPiece(MatchPlayerId, nTypeIdRook, 1, nFileNum));       // ChessPiece RookRight
            context.SaveChanges();
        }

        public void SetPawnRow(RealTimeChessDbContext context, int nRankNumber, int nBoardWidth )
        {
            ChessPieceType typePawn = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Pawn");
            int nPawnTypeId = typePawn.ChessPieceTypeId;
            for (int i=1; i<9; i++)
            {
                ChessPiece pawn = new ChessPiece(this.MatchPlayerId, nPawnTypeId, nRankNumber, i);
                context.ChessPiece.Add(pawn);
            }
            context.SaveChanges();
        }

        public void SetPawnColumn(RealTimeChessDbContext context, int nFileNumber, int nBoardHeight)
        {
            ChessPieceType typePawn = context.ChessPieceType.SingleOrDefault(t => t.ChessPieceTypeName == "Pawn");
            int nPawnTypeId = typePawn.ChessPieceTypeId;
            for (int i=1; i<9; i++)
            {
                ChessPiece pawn = new ChessPiece(this.MatchPlayerId, nPawnTypeId, i, nFileNumber);
                context.ChessPiece.Add(pawn);
            }
            context.SaveChanges();
        }




    }
}
