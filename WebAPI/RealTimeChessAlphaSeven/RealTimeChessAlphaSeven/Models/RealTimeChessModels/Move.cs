using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class Move
    {
        public int MoveId { get; set; }
        public string PlayerTypeName { get; set; }
        public int MatchPlayerId { get; set; }

        public string AlgebraicChessNotation { get; set; }
        public DateTime GameClockBeginMove { get; set; }
        public DateTime GameClockEndMove { get; set; }
        public string PositionBeginMove { get; set; }
        public string PositionEndMove { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
