using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChessAlphaSeven.Models.RealTimeChessModels
{
    public class Move
    {
        public int MoveId { get; set; }

        public int ChessPieceId { get; set; }

        public string AlgebraicChessNotation { get; set; }
        public DateTime? GameClockBeginMove { get; set; }
        public DateTime? GameClockEndMove { get; set; }

        public int? PositionBeginX { get; set; }
        public int? PositionBeginY { get; set; }

        public int PositionEndX { get; set; }
        public int PositionEndY { get; set; }

        public float? PositionCurrentX { get; set; }
        public float? PositionCurrentY { get; set; }

        public double? Distance { get; set; }
        public double? Velocity { get; set; }
        public TimeSpan? TravelTime { get; set; }

        public float? Heading { get; set; }
        public float? HeadingSin { get; set; }
        public float? HeadingCos { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Deleted { get; set; }

        [NotMapped]
        public Timer MoveTimer;

        public Move()
        {
            IsDeleted = false;
            Created = DateTime.Now;
        }

        public Move(int nChessPieceId, int nDestinationX, int nDestinationY, double dVelocity )
        {
            ChessPieceId = nChessPieceId;
            PositionEndX = nDestinationX;
            PositionEndY = nDestinationY;
            Velocity = dVelocity;
            IsDeleted = false;
            Created = DateTime.Now;
        }

        async public void Begin(RealTimeChessDbContext dbContext)
        {
            ChessPiece piece = await dbContext.ChessPiece.SingleOrDefaultAsync(chessPiece => chessPiece.ChessPieceId == ChessPieceId);
            PositionBeginX = piece.LocationX;
            PositionBeginY = piece.LocationY;

            // calculate legs of right triangle
            int nDistanceX = (int) PositionEndX - (int)PositionBeginX;
            int nDistanceY = (int) PositionEndY - (int)PositionBeginY;

            // Calculate Hypotenuse of right triangle
            Distance = Math.Sqrt((nDistanceX * nDistanceX) + (nDistanceY * nDistanceY));

            TravelTime = TimeSpan.FromSeconds( (double)Distance / (double)Velocity);
            GameClockBeginMove = DateTime.Now;
            GameClockEndMove = GameClockBeginMove + TravelTime;


        }


    }

}
