using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TexasRealTimeChess.Models.RealTimeChessModels
{
    public class ChessPieceType
    {
        public int ChessPieceTypeId { get; set; }
        public string ChessPieceTypeName { get; set; }
        public int ChessPieceScoreValue { get; set; }
        public int Velocity { get; set; }
        public string ImagePath { get; set; }

        // public List<ChessPiece> ChessPieces { get; set; }

        [NotMapped]
        public Func<Array> LegalMoves { get; set; }

    }
}
