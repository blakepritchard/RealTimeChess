﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TexasRealTimeChess.Models.RealTimeChessModels;

namespace TexasRealTimeChess.Data
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            PlayerType ptWhite = new PlayerType();
            PlayerType ptBlack = new PlayerType();
            PlayerType ptRed = new PlayerType();
            PlayerType ptBlue = new PlayerType();

            ptWhite.PlayerTypeName = "White";
            ptBlack.PlayerTypeName = "Black";
            ptRed.PlayerTypeName = "Red";
            ptBlue.PlayerTypeName = "Blue";

            ptWhite.TurnOrder = 1;
            ptBlack.TurnOrder = 2;
            ptRed.TurnOrder = 3;
            ptBlue.TurnOrder = 4;
        }

    }
}
