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
       
        public bool IsCaptured { get; set; }
        public int LocationRankNum { get; set; }
        public int LocationFileNum { get; set; }

        public bool IsMoving { get; set; }
        public DateTime DepartureTime { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Velocity { get; set; }
        public float Heading { get; set; }
        public float HeadingSin { get; set; }
        public float HeadingCos { get; set; }

        public DateTime ArrivalTime { get; set; }
        public int DestinationRankNum { get; set; }
        public int DestinationFileNum { get; set; }

        public string DestinationCoordinates { get; set; }

        public ChessPiece()
        {
            IsCaptured = false;
        }

        public ChessPiece(int nMatchPlayerId, int nChessPieceTypeId, int nLocationRank, int nLocationFile)
        {
            MatchPlayerId = nMatchPlayerId;
            ChessPieceTypeId = nChessPieceTypeId;
            LocationRankNum = nLocationRank;
            LocationFileNum = nLocationFile;
            IsCaptured = false;
        }

        public string LocationFileChar()
        {
            char c = 'a';
            for(int i = 0; i<LocationFileNum; i++)
            {
                c++;
            }
            return c.ToString();

        }

        public string LocationCoordinates()
        {
            return string.Format("%%", LocationFileChar(), LocationRankNum);
        }

        public void BeginMove(int nDestinationX, int nDestinationY)
        {
            IsMoving = true;
            LocationRankNum = 0;
            LocationFileNum = 0;
            DestinationRankNum = nDestinationX;
            DestinationFileNum = nDestinationY;
        }

        public void EndMove(int nDestinationX, int nDestinationY)
        {
            IsMoving = false;
            LocationRankNum = nDestinationX;
            LocationFileNum = nDestinationY;
            DestinationRankNum = 0;
            DestinationFileNum = 0;
        }

    }
}
