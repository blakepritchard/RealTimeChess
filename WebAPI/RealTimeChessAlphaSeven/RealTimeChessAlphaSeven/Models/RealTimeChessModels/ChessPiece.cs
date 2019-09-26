using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TexasRealTimeChess.Models.RealTimeChessModels
{
    public class ChessPiece
    {
        public int ChessPieceId { get; set; }

        public int MatchPlayerId { get; set; }
        //public MatchPlayer MatchPlayer { get; set; }

        public int ChessPieceTypeId { get; set; }
        public ChessPieceType ChessPieceType { get; set; }

        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public bool IsCaptured { get; set; }
        public bool IsMoving { get; set; }

        public List<Move> Moves { get; set; }      

        public ChessPiece()
        {
            IsCaptured = false;
            Moves = new List<Move>();
        }

        public ChessPiece(int nMatchPlayerId, int nChessPieceTypeId, int nLocationRank, int nLocationFile)
        {
            MatchPlayerId = nMatchPlayerId;
            ChessPieceTypeId = nChessPieceTypeId;
            LocationY = nLocationRank;
            LocationX = nLocationFile;
            IsCaptured = false;
        }

        public string LocationFileChar()
        {
            char c = 'a';
            for(int i = 0; i<LocationX; i++)
            {
                c++;
            }
            return c.ToString();

        }

        public string LocationCoordinates()
        {
            return string.Format("%%", LocationFileChar(), LocationY);
        }

        public void BeginMove(int nDestinationX, int nDestinationY)
        {
            IsMoving = true;
            LocationY = 0;
            LocationX = 0;
        }

        public void EndMove(int nDestinationX, int nDestinationY)
        {
            IsMoving = false;
            LocationY = nDestinationX;
            LocationX = nDestinationY;
        }

    }
}
