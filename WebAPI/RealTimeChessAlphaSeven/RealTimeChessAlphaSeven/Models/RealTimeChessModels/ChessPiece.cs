using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class ChessPiece
    {
        public int ChessPieceId { get; set; }
        public int MatchPlayerId { get; set; }
        public int ChessPieceTypeId { get; set; }


        public string LocationCoordinates { get; set; }
        public int LocationRankNum { get; set; }
        public string LocationFileLetter { get; set; }
        
        public bool IsMoving { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Velocity { get; set; }
        public float Heading { get; set; }
        public string DestinationCoordinates { get; set; }

        public ChessPiece(int nMatchPlayerId, int nChessPieceTypeId, int nLocationRank, string strLocationFile)
        {
            MatchPlayerId = nMatchPlayerId;
            ChessPieceTypeId = nChessPieceTypeId;
            LocationRankNum = nLocationRank;
            LocationFileLetter = strLocationFile;
            LocationCoordinates = string.Format("%%", strLocationFile, nLocationRank) ;
        }
    }
}
