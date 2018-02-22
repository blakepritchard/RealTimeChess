﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class ChessMatch
    {
        public int ChessMatchId { get; set; }
        public string PlayerTypeName { get; set; }

        public DateTime MatchStartTime { get; set; }
        public DateTime MatchEndTime { get; set; }
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public List<MatchPlayer> MatchPlayers { get; set; }
    }
}