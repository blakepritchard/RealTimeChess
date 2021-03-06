﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class PlayerType
    {
        public int PlayerTypeId { get; set; }
        public string PlayerTypeName { get; set; }
        public int TurnOrder { get; set; }

        public List<MatchPlayer> MatchPlayers { get; set; }
    }
}
