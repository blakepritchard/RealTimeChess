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
        public Move(int? moveId = default(int?), string playerTypeName = default(string), int? matchPlayerId = default(int?), string algebraicChessNotation = default(string), DateTime? gameClockBeginMove = default(DateTime?), DateTime? gameClockEndMove = default(DateTime?), string positionBeginMove = default(string), string positionEndMove = default(string), bool? isDeleted = default(bool?), DateTime? created = default(DateTime?), DateTime? updated = default(DateTime?), DateTime? deleted = default(DateTime?))
        {
            MoveId = moveId;
            PlayerTypeName = playerTypeName;
            MatchPlayerId = matchPlayerId;
            AlgebraicChessNotation = algebraicChessNotation;
            GameClockBeginMove = gameClockBeginMove;
            GameClockEndMove = gameClockEndMove;
            PositionBeginMove = positionBeginMove;
            PositionEndMove = positionEndMove;
            IsDeleted = isDeleted;
            Created = created;
            Updated = updated;
            Deleted = deleted;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moveId")]
        public int? MoveId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "playerTypeName")]
        public string PlayerTypeName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "matchPlayerId")]
        public int? MatchPlayerId { get; set; }

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
        [JsonProperty(PropertyName = "positionBeginMove")]
        public string PositionBeginMove { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "positionEndMove")]
        public string PositionEndMove { get; set; }

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
