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
        public string Location { get; set; }
        public string Destination { get; set; }

        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Velocity { get; set; }
        public float Heading { get; set; }
        
    }
}
