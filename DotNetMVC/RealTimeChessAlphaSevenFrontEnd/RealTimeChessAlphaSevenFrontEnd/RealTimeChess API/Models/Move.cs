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

    public partial class Move
    {
        /// <summary>
        /// Initializes a new instance of the Move class.
        /// </summary>
        public Move() { }

        /// <summary>
        /// Initializes a new instance of the Move class.
        /// </summary>
        public Move(object moveTimer = default(object), int? moveId = default(int?), int? chessPieceId = default(int?), string algebraicChessNotation = default(string), DateTime? gameClockBeginMove = default(DateTime?), DateTime? gameClockEndMove = default(DateTime?), int? positionBeginX = default(int?), int? positionBeginY = default(int?), int? positionEndX = default(int?), int? positionEndY = default(int?), double? positionCurrentX = default(double?), double? positionCurrentY = default(double?), double? distance = default(double?), double? velocity = default(double?), string travelTime = default(string), double? heading = default(double?), double? headingSin = default(double?), double? headingCos = default(double?), bool? isDeleted = default(bool?), DateTime? created = default(DateTime?), DateTime? updated = default(DateTime?), DateTime? deleted = default(DateTime?))
        {
            MoveTimer = moveTimer;
            MoveId = moveId;
            ChessPieceId = chessPieceId;
            AlgebraicChessNotation = algebraicChessNotation;
            GameClockBeginMove = gameClockBeginMove;
            GameClockEndMove = gameClockEndMove;
            PositionBeginX = positionBeginX;
            PositionBeginY = positionBeginY;
            PositionEndX = positionEndX;
            PositionEndY = positionEndY;
            PositionCurrentX = positionCurrentX;
            PositionCurrentY = positionCurrentY;
            Distance = distance;
            Velocity = velocity;
            TravelTime = travelTime;
            Heading = heading;
            HeadingSin = headingSin;
            HeadingCos = headingCos;
            IsDeleted = isDeleted;
            Created = created;
            Updated = updated;
            Deleted = deleted;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moveTimer")]
        public object MoveTimer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moveId")]
        public int? MoveId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "chessPieceId")]
        public int? ChessPieceId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "algebraicChessNotation")]
        public string AlgebraicChessNotation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gameClockBeginMove")]
        public DateTime? GameClockBeginMove { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gameClockEndMove")]
        public DateTime? GameClockEndMove { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "positionBeginX")]
        public int? PositionBeginX { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "positionBeginY")]
        public int? PositionBeginY { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "positionEndX")]
        public int? PositionEndX { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "positionEndY")]
        public int? PositionEndY { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "positionCurrentX")]
        public double? PositionCurrentX { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "positionCurrentY")]
        public double? PositionCurrentY { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "velocity")]
        public double? Velocity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "travelTime")]
        public string TravelTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "heading")]
        public double? Heading { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "headingSin")]
        public double? HeadingSin { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "headingCos")]
        public double? HeadingCos { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deleted")]
        public DateTime? Deleted { get; set; }

    }
}
