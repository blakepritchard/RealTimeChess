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
    }
}
