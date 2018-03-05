﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace RealTimeChessAlphaSevenFrontEnd.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class ChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the ChessPiece class.
        /// </summary>
        public ChessPiece() { }

        /// <summary>
        /// Initializes a new instance of the ChessPiece class.
        /// </summary>
        public ChessPiece(int? chessPieceId = default(int?), int? matchPlayerId = default(int?), int? chessPieceTypeId = default(int?), int? locationX = default(int?), int? locationY = default(int?), bool? isCaptured = default(bool?), bool? isMoving = default(bool?), IList<Move> moves = default(IList<Move>))
        {
            ChessPieceId = chessPieceId;
            MatchPlayerId = matchPlayerId;
            ChessPieceTypeId = chessPieceTypeId;
            LocationX = locationX;
            LocationY = locationY;
            IsCaptured = isCaptured;
            IsMoving = isMoving;
            Moves = moves;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "chessPieceId")]
        public int? ChessPieceId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "matchPlayerId")]
        public int? MatchPlayerId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "chessPieceTypeId")]
        public int? ChessPieceTypeId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "locationX")]
        public int? LocationX { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "locationY")]
        public int? LocationY { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isCaptured")]
        public bool? IsCaptured { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isMoving")]
        public bool? IsMoving { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moves")]
        public IList<Move> Moves { get; set; }

    }
}
