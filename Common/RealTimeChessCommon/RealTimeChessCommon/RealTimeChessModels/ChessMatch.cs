using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{


    public class ChessMatch
    {
        public int ChessMatchId { get; set; }
        public int NumPlayers{ get; set; }

        public DateTime MatchStartTime { get; set; }
        public DateTime? MatchEndTime { get; set; }
        public bool IsSetup { get; set; }
        public bool HasStarted { get; set; }
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public List<MatchPlayer> MatchPlayers { get; set; }

        [NotMapped]
        public static double ChessPieceVelocity = 1.0;

        public ChessMatch()
        {
            IsActive = false;
            HasStarted = false;
            IsSetup = false;
        }

        public bool SetUpChessBoard(RealTimeChessDbContext context, int nBoardWidth, int nBoardHeight)
        {
            bool bSuccess = true;
            if (false == IsSetup)
            {
                foreach (MatchPlayer matchPlayer in this.MatchPlayers)
                {
                    IsSetup = matchPlayer.SetUpChessPieces(context, this.NumPlayers, nBoardWidth, nBoardHeight);
                    //context.Entry(matchPlayer).Collection(p => p.Pieces).Load();
                }
                IsSetup = true;
                context.SaveChanges();
            }
            else
            {
                bSuccess = false;
            }
            return bSuccess;
        }

    }


}
