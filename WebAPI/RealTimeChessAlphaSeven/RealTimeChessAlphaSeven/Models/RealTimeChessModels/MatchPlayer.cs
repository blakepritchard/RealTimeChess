using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class MatchPlayer
    {
        public int MatchPlayerId { get; set; }
        public int ChessMatchId { get; set; }
        public int PlayerId { get; set; }
        public int PlayerTypeId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public List<Move> Moves { get; set; }
        public List<ChessPiece> Pieces { get; set; }

        public bool SetUpChessPieces(RealTimeChessDbContext _context, int NumPlayers, int BoardWidth, int BoardHeight)
        {
            bool bSuccess = true;





            if (2 == NumPlayers)
            {
                switch (PlayerTypeId)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;

                }
            }
            return bSuccess;

        }

        public int GetChessPieceTypeIdByName(RealTimeChessDbContext _context, string TypeName)
        {
            var dbsetChessPieceTypes = from t in _context.ChessPieceType select t;
            ChessPieceType typePiece = dbsetChessPieceTypes.Where(t => t.ChessPieceTypeName.Equals(TypeName)).First();
            return typePiece.ChessPieceTypeId;
        }

        public bool SetPawnRow(RealTimeChessDbContext _context, int RankNumber, int BoardWidth )
        {
            bool bSuccess = true;
            int nPawnTypeId = GetChessPieceTypeIdByName(_context, "Pawn");
            for (int i=0; i<8; i++)
            {

                // ChessPiece pawn = new ChessPiece(this.MatchPlayerId, nPawnTypeId
            }
            return bSuccess;

        }

        public bool SetPawnColumn(char FileLetter, int BoardHeight)
        {
            bool bSuccess = true;

            return bSuccess;

        }




    }
}
